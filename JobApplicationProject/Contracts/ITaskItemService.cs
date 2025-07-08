using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobApplicationProject.DTOs;

namespace JobApplicationProject.Contracts
{
    public interface ITaskItemService : IGenericService<TaskItem,TaskItemDto>
    {
        Task<IEnumerable<TaskItemDto>> GetTaskItemsByProjectIdAsync(long projectId);
    }
} 