using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.EntitiesConfiguration;

namespace SimpleChat.Infrastructure.Data
{
    public class CastomTaskTrackerDbContext : DbContext
    {
        public DbSet<CastomTask> CastomTasks { get; set; }

        public CastomTaskTrackerDbContext(DbContextOptions<CastomTaskTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CastomTaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}