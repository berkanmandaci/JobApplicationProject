using JobApplicationProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobApplicationProject.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        // Şu an için ekstra metot yok, eklenirse buraya yazılabilir
    }
} 