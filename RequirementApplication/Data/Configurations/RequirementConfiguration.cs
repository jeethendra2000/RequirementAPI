using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequirementAPI.Models;
using RequirementAPI.Models.Enums;

namespace RequirementAPI.Data.Configurations
{
    public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.ToTable("Requirements", b => b.IsTemporal());

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Description)
                .HasMaxLength(2000);

            builder.Property(r => r.Status)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.HasMany(r => r.Tasks)
                .WithOne(t => t.Requirement)
                .HasForeignKey(t => t.RequirementId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Tags)
                .WithMany(t => t.Requirements)
                .UsingEntity(j => j.ToTable("RequirementTags"));

            builder.HasData(
                new Requirement
                {
                    Id = 1,
                    Title = "User Authentication",
                    Description = "Implement secure login.",
                    Status = Status.New
                },
                new Requirement
                {
                    Id = 2,
                    Title = "Product Management",
                    Description = "Implement product CRUD.",
                    Status = Status.New
                },
                new Requirement
                {
                    Id = 3,
                    Title = "Reporting Dashboard",
                    Description = "Implement reporting features.",
                    Status = Status.New
                }
            );
        }
    }
}
