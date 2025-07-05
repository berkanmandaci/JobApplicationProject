using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(long id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(long id, T entity);
        Task<bool> DeleteAsync(long id);
    }
} 