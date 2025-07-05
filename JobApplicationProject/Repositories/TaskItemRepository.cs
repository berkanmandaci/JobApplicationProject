using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationProject.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TodoContext _context;

        public TaskItemRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(long id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
        }

        public void Update(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
        }

        public void Delete(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Exists(long id)
        {
            return _context.TaskItems.Any(e => e.Id == id);
        }


        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(long projectId)
        {
            return await _context.TaskItems
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
    }
} 