using JobApplicationProject.Models;

namespace JobApplicationProject.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(long id);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(long id, Project project);
        Task<bool> DeleteProjectAsync(long id);
    }
} 