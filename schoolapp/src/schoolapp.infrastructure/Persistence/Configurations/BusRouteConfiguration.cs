using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Transportation;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BusRouteConfiguration : IEntityTypeConfiguration<BusRoute>
    {
        public void Configure(EntityTypeBuilder<BusRoute> busRouteConfiguration)
        {
            busRouteConfiguration.ToTable("bus_routes", "transportation");

            busRouteConfiguration.Property(s => s.RouteName)
                .HasColumnName("route_name")
                .HasMaxLength(100);

            busRouteConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}