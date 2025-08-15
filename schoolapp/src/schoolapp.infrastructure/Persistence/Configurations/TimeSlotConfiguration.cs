using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Timetable;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> timeSlotConfiguration)
        {
            timeSlotConfiguration.ToTable("time_slots", "timetable");
        }
    }
}