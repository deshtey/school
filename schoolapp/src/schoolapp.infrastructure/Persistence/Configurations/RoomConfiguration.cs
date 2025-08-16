using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Hostel;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> roomConfiguration)
        {
            roomConfiguration.ToTable("rooms", "hostel");

            roomConfiguration.Property(s => s.RoomNumber);
        }
    }
}