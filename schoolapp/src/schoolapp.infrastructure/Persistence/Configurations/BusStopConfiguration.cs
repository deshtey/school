using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Transportation;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> busStopConfiguration)
        {
            busStopConfiguration.ToTable("bus_stops", "transportation");

            busStopConfiguration.Property(s => s.StopName)
                .HasColumnName("stop_name")
                .HasMaxLength(100);

            busStopConfiguration.Property(s => s.Location)
                .HasColumnName("location")
                .HasMaxLength(200);
        }
    }
}