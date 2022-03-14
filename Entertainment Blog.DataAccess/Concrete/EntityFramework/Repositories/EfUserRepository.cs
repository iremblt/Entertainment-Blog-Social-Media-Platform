using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserRepository:EfGenericRepository<ApplicationUser>,IUserRepository
    {
        public EfUserRepository(EntertainmentBlogContext context):base(context)
        {

        }
        public async Task<List<ApplicationUser>> UserListAsync()
        {
            return await context.Users.Include(i => i.Posts).ToListAsync();
        }        
        public async Task<ApplicationUser> UserDetailsAsync(ApplicationUser user)
        {
           return await context.Users.Include(i => i.Posts).FirstOrDefaultAsync(i=>i.Id==user.Id);
        }
        public async Task<ApplicationUser> UserIdWithAsNoTracking(string id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(i=>i.Id==id);
        }
    }
}
