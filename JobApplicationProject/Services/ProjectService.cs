using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Services
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        public ProjectService(IProjectRepository repository) : base(repository)
        {
        }
    }
} 