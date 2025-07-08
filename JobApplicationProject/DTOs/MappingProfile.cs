using AutoMapper;
using JobApplicationProject.Models;

namespace JobApplicationProject.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        }
    }
}
