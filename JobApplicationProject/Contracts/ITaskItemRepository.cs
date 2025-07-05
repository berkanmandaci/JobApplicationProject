using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(long id);
        Task AddAsync(TaskItem taskItem);
        void Update(TaskItem taskItem);
        void Delete(TaskItem taskItem);
        Task<bool> SaveChangesAsync();
        bool Exists(long id);
        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(long projectId);
    }
} 