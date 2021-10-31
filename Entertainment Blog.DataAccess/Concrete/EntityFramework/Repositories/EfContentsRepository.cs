using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfContentsRepository:EfGenericRepository<Contents>,IContentsRepository
    {
        public EfContentsRepository(EntertainmentBlogContext context):base(context)
        {
        }
        public async Task<List<Contents>> GetContentsIncludePost()
        {
            return await context.Contents.Include(i => i.Post).ToListAsync();
        }
        public async Task<List<Contents>> GetContentsByPostIdAsync(int postid)
        {
            var list = await context.Contents.Include(i=>i.Post).ToListAsync();
            var contents = new List<Contents>();
            foreach (var content in list)
            {
                if (content.PostId == postid)
                {
                    contents.Add(content);
                }
            }
            return contents;
        }
    }
}
