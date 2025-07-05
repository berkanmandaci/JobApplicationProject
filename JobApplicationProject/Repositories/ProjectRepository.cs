using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationProject.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TodoContext _context;

        public ProjectRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.TaskItems).ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(long id)
        {
            return await _context.Projects
                                 .Include(p => p.TaskItems)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Update(Project project)
        {
            var existing = _context.Projects.Find(project.Id);
            if (existing != null)
            {
                existing.Name = project.Name;
                existing.Description = project.Description;
                // Diğer property'ler varsa burada güncellenebilir
                _context.SaveChanges();
            }
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Exists(long id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
} 