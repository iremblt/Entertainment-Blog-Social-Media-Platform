using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task<T> DeleteAsync(int id);
        Task<int> SaveAsync();
    }
}
