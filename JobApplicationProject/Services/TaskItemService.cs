using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Services
{
    public class TaskItemService : GenericService<TaskItem>, ITaskItemService
    {
        private readonly ITaskItemRepository _repository;

        public TaskItemService(ITaskItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsByProjectIdAsync(long projectId)
        {
            return await _repository.GetByProjectIdAsync(projectId);
        }
    }
} 