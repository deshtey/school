using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Resources;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class ResourceCategoryConfiguration : IEntityTypeConfiguration<ResourceCategory>
    {
        public void Configure(EntityTypeBuilder<ResourceCategory> resourceCategoryConfiguration)
        {
            resourceCategoryConfiguration.ToTable("resource_categories", "resources");

            resourceCategoryConfiguration.Property(s => s.CategoryName)
                .HasColumnName("category_name")
                .HasMaxLength(100);

            resourceCategoryConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}