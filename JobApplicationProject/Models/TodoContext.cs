using Microsoft.EntityFrameworkCore;

namespace JobApplicationProject.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
    }
} 