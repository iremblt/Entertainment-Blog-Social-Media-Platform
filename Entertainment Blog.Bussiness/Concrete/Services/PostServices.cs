using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class PostServices : IPostService
    {
        private readonly IPostRepository postRepository;
        private IMapper mapper;
        public PostServices(IPostRepository _postRepository,IMapper _mapper)
        {
            postRepository = _postRepository;
            mapper = _mapper;
        }
        public async Task AddPostAsync(PostAddDTO post)
        {
            var adding = mapper.Map<PostAddDTO,Post>(post);
            await postRepository.AddAsync(adding);
        }

        public async Task DeletePostAsync(PostDeleteDTO post)
        {
            var delete = mapper.Map<PostDeleteDTO, Post>(post);
            await postRepository.DeleteAsync(delete.Id);
        }

        public async Task EditPostAsync(PostEditDTO post)
        {
            var updating = mapper.Map<PostEditDTO, Post>(post);
            await postRepository.UpdateAsync(updating);
        }

        public async Task<PostListDTO> GetPostByIdAsync(int id)
        {
            var result= await postRepository.GetByIdAsync(id);
            if (result == null) { return null; }
            return mapper.Map<Post,PostListDTO>(result);
        }

        public PostListDTO GetPostByIdIncludeCategories(int id)
        {
            var get = postRepository.GetPostByIdWithCategoriesAndTags(Types.PostCategories,id);
            return mapper.Map<Post, PostListDTO>(get);
        }

        public PostListDTO GetPostByIdIncludeCategoriesAndTags(int id)
        {
            var get = postRepository.GetPostByIdWithCategoriesAndTags(Types.PostCategories | Types.PostTags, id);
            return mapper.Map<Post, PostListDTO>(get);
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

        public List<PostListDTO> GetPostsIncludeCategories()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTags(Types.PostCategories);
            return mapper.Map<List<PostListDTO>>(lists);
        }

        public List<PostListDTO> GetPostsIncludeCategoriesAndTags()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTags(Types.PostCategories | Types.PostTags);
            return mapper.Map<List<PostListDTO>>(lists);
        }

        public List<PostListDTO> GetPostsIncludeTags()
        {
            var lists = postRepository.GetPostsIncludeCategoriesAndTags(Types.PostTags);
            return mapper.Map<List<PostListDTO>>(lists);
        }
    }
}
