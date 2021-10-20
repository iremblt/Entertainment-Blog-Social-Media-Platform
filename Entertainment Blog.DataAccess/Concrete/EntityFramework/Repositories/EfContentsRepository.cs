using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfContentsRepository:EfGenericRepository<Contents>,IContentsRepository
    {
        public EfContentsRepository(EntertainmentBlogContext context):base(context)
        {
        }
    }
}
