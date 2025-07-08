using System.ComponentModel.DataAnnotations;
using JobApplicationProject.Common;
namespace JobApplicationProject.DTOs
{
    public class TaskItemDto
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.TaskNameRequired)]
        public required string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public long ProjectId { get; set; }
    }
}
