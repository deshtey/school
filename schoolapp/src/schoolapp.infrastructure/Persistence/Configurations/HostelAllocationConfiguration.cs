using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Hostel;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class HostelAllocationConfiguration : IEntityTypeConfiguration<HostelAllocation>
    {
        public void Configure(EntityTypeBuilder<HostelAllocation> hostelAllocationConfiguration)
        {
            hostelAllocationConfiguration.ToTable("hostel_allocations", "hostel");

            hostelAllocationConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}