using Microsoft.EntityFrameworkCore;
using JobApplicationProject.Models;

namespace JobApplicationProject.Repositories
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
    }
} 