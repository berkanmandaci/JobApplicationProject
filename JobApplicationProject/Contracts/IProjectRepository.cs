using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(long id);
        Task AddAsync(Project project);
        void Update(Project project);
        void Delete(Project project);
        Task<bool> SaveChangesAsync();
        bool Exists(long id);
    }
} 