using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IContentsRepository:IGenericRepository<Contents>
    {
        Task<List<Contents>> GetContentsIncludePost();
        Task<List<Contents>> GetContentsByPostIdAsync(int postid);
    }
}
