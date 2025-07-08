using System.ComponentModel.DataAnnotations;

namespace JobApplicationProject.Models
{
    public class Project
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Project adı zorunludur.")]
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<TaskItem>? TaskItems { get; set; }
    }
}
