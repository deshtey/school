using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Hostel;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class HostelConfiguration : IEntityTypeConfiguration<Hostel>
    {
        public void Configure(EntityTypeBuilder<Hostel> hostelConfiguration)
        {
            hostelConfiguration.ToTable("hostels", "hostel");

            hostelConfiguration.Property(s => s.HostelName)
                .HasColumnName("hostel_name")
                .HasMaxLength(100);

            hostelConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

            hostelConfiguration.Property(s => s.Location)
                .HasColumnName("location")
                .HasMaxLength(200);
        }
    }
}