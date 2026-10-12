using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequirementAPI.Models;

namespace RequirementAPI.Data.Configurations
{
    public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.ToTable("Requirements");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Description)
                .HasMaxLength(2000);

            builder.HasMany(r => r.Tasks)
                .WithOne(t => t.Requirement)
                .HasForeignKey(t => t.RequirementId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Tags)
                .WithMany(t => t.Requirements)
                .UsingEntity(j => j.ToTable("RequirementTags"));
        }
    }
}
