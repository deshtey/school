using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Timetable;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class ClassScheduleConfiguration : IEntityTypeConfiguration<ClassSchedule>
    {
        public void Configure(EntityTypeBuilder<ClassSchedule> classScheduleConfiguration)
        {
            classScheduleConfiguration.ToTable("class_schedules", "timetable");

            classScheduleConfiguration.Property(s => s.DayOfWeek)
                .HasColumnName("day_of_week")
                .HasMaxLength(20);
        }
    }
}