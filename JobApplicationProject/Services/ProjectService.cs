using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();
            return project;
        }

        public async Task<bool> UpdateProjectAsync(long id, Project project)
        {
            if (id != project.Id)
            {
                return false;
            }

            _repository.Update(project);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            var projectToDelete = await _repository.GetByIdAsync(id);
            if (projectToDelete == null)
            {
                return false;
            }

            _repository.Delete(projectToDelete);
            return await _repository.SaveChangesAsync();
        }
    }
} 