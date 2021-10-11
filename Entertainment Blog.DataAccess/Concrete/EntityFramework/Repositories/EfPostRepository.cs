using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPostRepository:EfGenericRepository<Post>,IPostRepository
    {
        public EfPostRepository(EntertainmentBlogContext context) : base(context)
        {

        }
        private List<Post> IncludeTypes(Types types)
        {
            if (types.HasFlag(Types.PostCategories))
            {
               context.Posts.Include(i => i.PostCategories).ThenInclude(p => p.Category).Load();
            }
            if (types.HasFlag(Types.PostTags))
            {
                context.Tags.Include(i => i.PostTags).ThenInclude(t => t.Tag).Load();
            }
            return context.Posts.ToList();
        }
        public Post GetPostByIdWithCategoriesAndTags(Types types, int id)
        {
            var post = IncludeTypes(types).ToList();
            var result = post.FirstOrDefault(i => i.Id==id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
            
        }
        public List<Post> GetPostsIncludeCategoriesAndTags(Types types)
        {
            var lists = IncludeTypes(types).ToList();
            return lists;
        }
    }
}
