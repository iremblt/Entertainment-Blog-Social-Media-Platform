using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentRepository
    {
        public EfCommentRepository(EntertainmentBlogContext context) :base(context)
        {
        }
        public async Task<List<Comment>> CommentsListAsync()
        {
            return await context.Comments.Include(u => u.User).ToListAsync();
        }
        public async Task<Comment> CommentByIdIncludeUserAsync(int id)
        {
            return await context.Comments.Include(u=>u.User).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
