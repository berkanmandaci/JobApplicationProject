using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;

        public TaskItemService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem)
        {
            await _repository.AddAsync(taskItem);
            await _repository.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> UpdateTaskItemAsync(long id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return false;
            }

            _repository.Update(taskItem);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteTaskItemAsync(long id)
        {
            var taskItem = await _repository.GetByIdAsync(id);
            if (taskItem == null)
            {
                return false;
            }

            _repository.Delete(taskItem);
            return await _repository.SaveChangesAsync();
        }
    }
} 