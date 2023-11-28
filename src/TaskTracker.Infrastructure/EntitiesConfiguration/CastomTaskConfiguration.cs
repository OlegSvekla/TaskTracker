using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.EntitiesConfiguration
{
    public class CastomTaskConfiguration : IEntityTypeConfiguration<CastomTask>
    {
        public void Configure(EntityTypeBuilder<CastomTask> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(20); 

            builder.Property(t => t.Description)
                .IsRequired(); 

            builder.Property(t => t.CreationDate)
                .IsRequired();

            builder.Property(t => t.UpdateDate)
                .IsRequired(); 
        }
    }
}