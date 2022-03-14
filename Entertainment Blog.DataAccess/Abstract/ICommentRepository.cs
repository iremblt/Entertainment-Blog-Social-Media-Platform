using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface  ICommentRepository:IGenericRepository<Comment>
    {
        public Task<List<Comment>> CommentsListAsync();
        public Task<Comment> CommentByIdIncludeUserAsync(int id);
    }
}
