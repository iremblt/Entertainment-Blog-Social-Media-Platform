using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPostRepository : EfGenericRepository<Post>, IPostRepository
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public EfPostRepository(EntertainmentBlogContext context, ICategoryRepository _categoryRepository, ITagRepository _tagRepository,UserManager<ApplicationUser> _userManager) : base(context)
        {
            categoryRepository = _categoryRepository;
            tagRepository = _tagRepository;
            userManager = _userManager;
        }
        private List<Post> IncludeTypes(Types types)
        {
            if (types.HasFlag(Types.PostCategories))
            {
                context.Posts.Include(i => i.Contents).Include(i => i.Comments).Include(i => i.PostCategories).ThenInclude(p => p.Category).Load();
            }
            if (types.HasFlag(Types.PostTags))
            {
                context.Posts.Include(i => i.Contents).Include(i=>i.Comments).Include(i => i.PostTags).ThenInclude(t => t.Tag).Load();
            }
            return context.Posts.ToList();
        }
        public Post GetPostByIdWithCategoriesAndTags(Types types, int id)
        {
            var post = IncludeTypes(types).ToList();
            var result = post.FirstOrDefault(i => i.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }   
        public async Task<List<Post>> PostsWithUsers()
        {
            var posts = await context.Posts.ToListAsync();
            foreach (var user in posts)
            {
                if (user.UserId != null)
                {
                    var finduser = await userManager.FindByIdAsync(user.UserId);
                    user.User = finduser;
                }
            }
            return posts;
        }
        public List<Post> GetPostsIncludeCategoriesAndTagsAsync(Types types)
        {
            var lists = IncludeTypes(types).ToList();
            return lists;
        } 
        //public async Task<Post> GetPostIdIncludeTags(int id)
        //{
        //    var post= await context.Posts.Include(i => i.Contents).Include(i => i.PostTags).ThenInclude(t => t.Tag).FirstOrDefaultAsync(i=>i.Id==id);
        //    return post;
        //}
        public async Task<IQueryable<Post>> GetPostsOrderByDate()
        {
            var posts= await PostsWithUsers();
            return posts.OrderByDescending(d=>d.PublishDate).AsQueryable();
        }
        public IQueryable<Post> SearchPost(String text)
        {
            var post = context.Posts
                .Where(i =>
                i.Title.ToLower().Contains(text.ToLower()) ||
                i.Summary.ToLower().Contains(text.ToLower()));
            return post;
        }
        public async Task<Post> AddCategoryForPost(Post post, List<int> CategoryIds)
        {
            if (CategoryIds != null)
            {
                foreach (var category in CategoryIds)
                {
                    var postCategory = new PostCategory()
                    {
                        CategoryId = category,
                        Post = post,
                        PostId = post.Id,
                        Category = await categoryRepository.GetByIdAsync(category)
                    };
                    post.PostCategories.Add(postCategory);
                }
            }
            return post;
        }
        public async Task<Post> AddTagForPost(Post post, List<int> TagIds)
        {
            if (TagIds != null)
            {
                foreach (var tag in TagIds)
                {
                    var postTag = new PostTag()
                    {
                        TagId = tag,
                        Post = post,
                        PostId = post.Id,
                        Tag = await tagRepository.GetByIdAsync(tag)
                    };
                    post.PostTags.Add(postTag);
                }
            }
            return post;
        }
        public Post GetPostByIdWithContents(int id)
        {
            var result = context.Posts.Include(p => p.Contents)
                .AsNoTracking() // Id' i alınca oyle olurdu bunu yazmamım amacı değişklik olsun ya da olmasın kaydetmiyor.Sadece okuyor.
                .FirstOrDefault(i => i.Id == id);
            return result;
        }        
        public Post GetPostByIdWithEvertyhing(int id)
        {
            var result= context.Posts.Include(i => i.Contents).Include(i => i.Comments).Include(i => i.PostTags).ThenInclude(t => t.Tag)
                .AsNoTracking() // Id' i alınca oyle olurdu bunu yazmamım amacı değişklik olsun ya da olmasın kaydetmiyor.Sadece okuyor.
                .FirstOrDefault(i => i.Id == id);
            return result;
        }
    }
}
