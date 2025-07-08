using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface IGenericService<TEntity, TDto>
        where TEntity : class
        where TDto : class
   
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(long id);
        Task<TDto> CreateAsync(TDto entity);
        Task<bool> UpdateAsync(long id, TDto entity);
        Task<bool> DeleteAsync(long id);
    }
} 