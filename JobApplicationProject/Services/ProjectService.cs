using AutoMapper;
using JobApplicationProject.Contracts;
using JobApplicationProject.DTOs;
using JobApplicationProject.Models;

namespace JobApplicationProject.Services
{
    public class ProjectService : GenericService<Project, ProjectDto>, IProjectService
    {
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
    }
} 