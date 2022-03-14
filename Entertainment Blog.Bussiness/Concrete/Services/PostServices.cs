using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.SearchDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class PostServices : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IUserService userService;
        private IMapper mapper;
        public PostServices(IPostRepository _postRepository, IMapper _mapper, ICategoryService _categoryService, ITagService _tagService,IUserService _userService)
        {
            postRepository = _postRepository;
            categoryService = _categoryService;
            tagService = _tagService;
            mapper = _mapper;
            userService = _userService;
        }   
        public async Task<Post> AddPostAsync(PostAddDTO post)
        {
            var adding = mapper.Map<PostAddDTO, Post>(post);
            await postRepository.AddAsync(adding);
            await postRepository.AddCategoryForPost(adding, post.CategoryIds);
            var added = await postRepository.AddTagForPost(adding, post.TagIds);
            await postRepository.SaveAsync();
            return added;
        }

        public async Task DeletePostAsync(PostDeleteDTO post)
        {
            var delete = mapper.Map<PostDeleteDTO, Post>(post);
            await postRepository.DeleteAsync(delete.Id);
        }

        public async Task<Post> EditPostAsync(PostEditDTO post)
        {
            var beforeupdating = postRepository.GetPostByIdWithContents(post.Id);
            var updating = mapper.Map<PostEditDTO, Post>(post, postRepository.GetPostByIdWithCategoriesAndTags(Types.PostCategories | Types.PostTags, post.Id));
            updating.PublishDate = beforeupdating.PublishDate;
            updating.Contents = beforeupdating.Contents;
            updating.UserId= beforeupdating.UserId;
            await postRepository.AddCategoryForPost(updating, post.CategoryIds);
            var editted = await postRepository.AddTagForPost(updating, post.TagIds);
            await postRepository.UpdateAsync(editted);
            return editted;
        }
        public async Task<PostListDTO> GetPostByIdAsync(int id)
        {
            var result = await postRepository.GetByIdAsync(id);
            if (result == null) { return null; }
            return mapper.Map<Post, PostListDTO>(result);
        }

        public PostListDTO GetPostByIdIncludeCategories(int id)
        {
            var get = postRepository.GetPostByIdWithCategoriesAndTags(Types.PostCategories, id);
            return mapper.Map<Post, PostListDTO>(get);
        }
        public PostEditDTO GetEditPostByIdIncludeCategoriesAndTags(int id)
        {
            var get = postRepository.GetPostByIdWithCategoriesAndTags(Types.PostCategories | Types.PostTags, id);
            return mapper.Map<Post, PostEditDTO>(get);
        }

        public PostListDTO GetPostByIdIncludeTags(int id)
        {
            var get = postRepository.GetPostByIdWithCategoriesAndTags(Types.PostTags, id);
            return mapper.Map<Post, PostListDTO>(get);
        }

        public async Task<List<PostListDTO>> GetPostsAsync()
        {
            var lists = await postRepository.GetAllAsync();
            return mapper.Map<List<PostListDTO>>(lists);
        }
        public async Task<List<PostListDTO>> GetPostsOrderByDateTime()
        {
            var lists = await postRepository.GetPostsOrderByDate();
            return mapper.Map<List<PostListDTO>>(lists);
        }

        public List<PostListDTO> GetPostsIncludeCategories()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTagsAsync(Types.PostCategories);
            return mapper.Map<List<PostListDTO>>(lists);
        }

        public List<PostListDTO> GetPostsIncludeCategoriesAndTags()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTagsAsync(Types.PostCategories | Types.PostTags);
            return mapper.Map<List<PostListDTO>>(lists);
        }

        public List<PostListDTO> GetPostsIncludeTags()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTagsAsync(Types.PostTags);
            return mapper.Map<List<PostListDTO>>(lists);
        }
        public PostListDTO GetPostByIdWithEvertyhing(int id)
        {
            var post= postRepository.GetPostByIdWithEvertyhing(id);
            return mapper.Map<PostListDTO>(post);
        }
        public async Task<PostNextAndLastDTO> GetNextAndLastPostOfThePostAsync(int id)
        {
            var detail = GetPostByIdIncludeTags(id);
            if (detail != null)
            {
                if (detail.UserId != null)
                {
                    var user = await userService.FindUserByIdAsync(detail.UserId);
                    if (user != null)
                    {
                        detail.User = user;
                    }
                }
                if (detail.Comments.Any())
                {
                    foreach (var comment in detail.Comments)
                    {
                        var user = await userService.FindUserById(comment.UserId);
                        comment.User = user;
                    }
                }
                int lastId = id - 1;
                int nextId = id + 1;
                var postModel = new PostNextAndLastDTO
                {
                    Post = detail,
                    PostNext = await GetPostByIdAsync(nextId),
                    PostLast = await GetPostByIdAsync(lastId)
                };
                return postModel;
            }
            else
            {
                var postModel = new PostNextAndLastDTO
                {
                    Post = detail,
                    PostNext = await GetPostByIdAsync(0),
                    PostLast = await GetPostByIdAsync(0)
                };
                return postModel;
            }
        }
        public IQueryable<PostListDTO> SearchPost(SearchDTO search)
        {
            var post = postRepository.SearchPost(search.Text).ToList();
            var mapping = mapper.Map<List<PostListDTO>>(post);
            return mapping.AsQueryable();
        }
        public async Task<EdittingPostTagsCategoryDTO> MappingToEdittingPostTagsCategoryDTO(PostEditDTO postEdit)
        {
            var editing = new EdittingPostTagsCategoryDTO()
            {
                PostEdit = postEdit,
                CategoryList = await categoryService.GetCategoriesAsync(),
                TagList = await tagService.GetTagsAsync(),
                SelectedCategories = postEdit.PostCategories,
                SelectedTags = postEdit.PostTags
            };
            return editing;
        }
        public async Task<List<PostListDTO>> GetPostByCategoryIdAsync(int id)
        {
            var categories = categoryService.GetCategoryByIdWithPost(id);
            var postlist = new List<PostListDTO>();
            foreach (var category in categories.PostCategories)
            {
                var post = await GetPostByIdAsync(category.PostId);
                if (post != null)
                {
                    postlist.Add(post);
                }
            }
            return postlist.OrderByDescending(i=>i.PublishDate).ToList();
        }
    }
}
