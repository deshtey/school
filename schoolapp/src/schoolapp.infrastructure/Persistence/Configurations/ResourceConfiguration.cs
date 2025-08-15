using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Resources;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resourceConfiguration)
        {
            resourceConfiguration.ToTable("resources", "resources");

            resourceConfiguration.Property(s => s.ResourceName)
                .HasColumnName("resource_name")
                .HasMaxLength(200);

            resourceConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            resourceConfiguration.Property(s => s.ResourceType)
                .HasColumnName("resource_type")
                .HasMaxLength(100);

            resourceConfiguration.Property(s => s.Location)
                .HasColumnName("location")
                .HasMaxLength(200);
        }
    }
}