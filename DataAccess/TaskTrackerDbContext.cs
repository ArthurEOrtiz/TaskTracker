using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.DataAccess
{
  public class TaskTrackerDbContext : DbContext
  {
    public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) { }

    public DbSet<UserTask> UserTasks { get; set; }
  }
}
