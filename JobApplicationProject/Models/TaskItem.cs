using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JobApplicationProject.Common;
namespace JobApplicationProject.Models
{
    public class TaskItem 
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.TaskNameRequired)]
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
        public long ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
