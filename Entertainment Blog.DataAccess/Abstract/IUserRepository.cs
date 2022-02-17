using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IUserRepository:IGenericRepository<ApplicationUser>
    {
        public Task<List<ApplicationUser>> UserListAsync();
        public Task<ApplicationUser> UserDetailsAsync(ApplicationUser user);

    }
}
