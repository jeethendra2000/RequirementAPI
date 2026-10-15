using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequirementAPI.Models;
using System.Reflection.Emit;

namespace RequirementAPI.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags", b => b.IsTemporal());

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasData(
                new Tag { Id = 1, Name = "Backend" },
                new Tag { Id = 2, Name = "Security" },
                new Tag { Id = 3, Name = "API" }
            );
        }
    }
}
