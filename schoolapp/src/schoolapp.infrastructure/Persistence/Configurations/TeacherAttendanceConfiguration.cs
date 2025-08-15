using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Attendance;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class TeacherAttendanceConfiguration : IEntityTypeConfiguration<TeacherAttendance>
    {
        public void Configure(EntityTypeBuilder<TeacherAttendance> teacherAttendanceConfiguration)
        {
            teacherAttendanceConfiguration.ToTable("teacher_attendance", "attendance");

            teacherAttendanceConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}