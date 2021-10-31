using Entertainment_Blog.Entity.Concrete;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IPostCategoryRepository:IGenericRepository<PostCategory>
    {
        PostCategory GetByPostCategoryId(int postid, int categoryid);
        Task RemoveAsync(PostCategory postCategory);
    }
}
