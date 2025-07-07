using System.Text.Json.Serialization;
namespace JobApplicationProject.Models
{
    public class TaskItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public long ProjectId { get; set; }

        [JsonIgnore]
        public Project? Project { get; set; }
    }
}
