using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class StudentSubjectConfiguration
    : IEntityTypeConfiguration<StudentSubject>
{
    public void Configure(EntityTypeBuilder<StudentSubject> StudentSubjectConfig)
    {
        StudentSubjectConfig.ToTable("student_subjects", "academics");

        StudentSubjectConfig.Property(s => s.SubjectName)
            .HasColumnName("subject_name")
            .HasMaxLength(100);

        StudentSubjectConfig
            .HasOne(c => c.Student)
            .WithMany()
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        StudentSubjectConfig
            .HasOne(c => c.ClassRoomSubject)
            .WithMany()
            .HasForeignKey(c => c.ClassroomSubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}