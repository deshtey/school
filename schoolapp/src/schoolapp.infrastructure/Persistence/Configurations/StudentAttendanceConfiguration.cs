using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Attendance;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> studentAttendanceConfiguration)
        {
            studentAttendanceConfiguration.ToTable("student_attendance", "attendance");

            studentAttendanceConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}