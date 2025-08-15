using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Resources;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class ResourceAllocationConfiguration : IEntityTypeConfiguration<ResourceAllocation>
    {
        public void Configure(EntityTypeBuilder<ResourceAllocation> resourceAllocationConfiguration)
        {
            resourceAllocationConfiguration.ToTable("resource_allocations", "resources");

            resourceAllocationConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}