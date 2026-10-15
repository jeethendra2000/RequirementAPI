using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequirementAPI.Models;

namespace RequirementAPI.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Tasks", b => b.IsTemporal());

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Create Login API",
                    RequirementId = 1
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Add Password Validation",
                    RequirementId = 1
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Create Product API",
                    RequirementId = 2
                },
                new TaskItem
                {
                    Id = 4,
                    Title = "Add Product Validation",
                    RequirementId = 2
                },
                new TaskItem
                {
                    Id = 5,
                    Title = "Create Report Endpoint",
                    RequirementId = 3
                }
            );
        }
    }
}
