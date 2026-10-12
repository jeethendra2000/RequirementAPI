using Microsoft.EntityFrameworkCore;
using RequirementAPI.Models;

namespace RequirementAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Requirement> Requirements => Set<Requirement>();

        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public DbSet<Tag> Tags => Set<Tag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
