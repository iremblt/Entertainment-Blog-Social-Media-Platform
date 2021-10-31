using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPostCategoryRepository:EfGenericRepository<PostCategory>,IPostCategoryRepository
    {
        public EfPostCategoryRepository(EntertainmentBlogContext context):base(context)
        {
                
        }
        public PostCategory GetByPostCategoryId(int postid,int categoryid)
        {
            var postCategories = context.PostCategories.Include(i => i.Category)
                .Include(p => p.Post)
                .AsNoTracking()
                .ToList();
            foreach (var item in postCategories)
            {
                if (item.PostId == postid && item.CategoryId == categoryid)
                {
                    return item;
                }
            }
            return null;
        }
        public async Task RemoveAsync(PostCategory postCategory)
        {
            context.PostCategories.Remove(postCategory);
            await SaveAsync();
        }
    }
}
