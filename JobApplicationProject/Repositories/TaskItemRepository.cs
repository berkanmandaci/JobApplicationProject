using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationProject.Repositories
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(TodoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(long projectId)
        {
            return await _dbSet
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
    }
} 