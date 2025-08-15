using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Transportation;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> busConfiguration)
        {
            busConfiguration.ToTable("buses", "transportation");

            busConfiguration.Property(s => s.BusNumber)
                .HasColumnName("bus_number")
                .HasMaxLength(20);

            busConfiguration.Property(s => s.Model)
                .HasColumnName("model")
                .HasMaxLength(50);

            busConfiguration.Property(s => s.DriverName)
                .HasColumnName("driver_name")
                .HasMaxLength(100);

            busConfiguration.Property(s => s.DriverPhone)
                .HasColumnName("driver_phone")
                .HasMaxLength(20);

            busConfiguration.Property(s => s.RouteName)
                .HasColumnName("route_name")
                .HasMaxLength(100);
        }
    }
}