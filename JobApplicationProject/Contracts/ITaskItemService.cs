using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
        Task<TaskItem?> GetTaskItemByIdAsync(long id);
        Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem);
        Task<bool> UpdateTaskItemAsync(long id, TaskItem taskItem);
        Task<bool> DeleteTaskItemAsync(long id);
        Task<IEnumerable<TaskItem>> GetTaskItemsByProjectIdAsync(long projectId);
    }
} 