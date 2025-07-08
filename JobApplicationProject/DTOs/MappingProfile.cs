using AutoMapper;
using JobApplicationProject.Models;

namespace JobApplicationProject.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap()
                .ForMember(dest => dest.TaskItems, opt => opt.Ignore());
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        }
    }
}
