using System.ComponentModel.DataAnnotations;
using JobApplicationProject.Common;
namespace JobApplicationProject.DTOs
{
    public class ProjectDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.ProjectNameRequired)]
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<TaskItemDto>? TaskItems { get; set; }
    }
}