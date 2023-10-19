using Microsoft.EntityFrameworkCore;
using backend;

namespace backend.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } 
    }
}
