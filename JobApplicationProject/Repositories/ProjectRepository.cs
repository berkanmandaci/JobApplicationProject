using JobApplicationProject.Contracts;
using JobApplicationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationProject.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TodoContext context) : base(context)
        {
        }
        // Şu an için Project entity'sine özel ekstra metot yok
    }
} 