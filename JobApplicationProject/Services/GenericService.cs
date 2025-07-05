using JobApplicationProject.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> UpdateAsync(long id, T entity)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;
            _repository.Update(entity);
            return await _repository.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;
            _repository.Delete(entity);
            return await _repository.SaveChangesAsync();
        }
    }
} 