using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(long projectId);
    }
} 