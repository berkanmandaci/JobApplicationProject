using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationProject.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TodoContext context) : base(context)
        {

        }
        public override async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbSet.Include(p => p.TaskItems).ToListAsync();
        }
    }
}
