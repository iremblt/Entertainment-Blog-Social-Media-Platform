using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EntertainmentBlogContext context;
        private readonly DbSet<T> _dbSet;
        public EfGenericRepository(EntertainmentBlogContext _context)
        {
             context = _context;
            _dbSet = this.context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<T>AddAsync(T t)
        {
            var adding = await _dbSet.AddAsync(t);
            await SaveAsync();
            return adding.Entity;
        }

        public async Task<T> UpdateAsync(T t)
        {
            var updating=_dbSet.Update(t);
            await SaveAsync();
            return updating.Entity;
        }
        public async Task<T> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                var deleting = _dbSet.Remove(result);
                await SaveAsync();
                return deleting.Entity;
            }
        }
    }
}
