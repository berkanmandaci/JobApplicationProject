using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface ITaskItemService : IGenericService<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetTaskItemsByProjectIdAsync(long projectId);
    }
} 