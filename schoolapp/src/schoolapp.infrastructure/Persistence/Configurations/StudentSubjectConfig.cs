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

        //StudentSubjectConfig.Property(s => s.Name)
        //    .HasColumnName("subject_name")
        //    .HasMaxLength(100);

        StudentSubjectConfig
            .HasOne(c => c.Student)
            .WithMany(c=>c.EnrolledSubjects)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        //StudentSubjectConfig
        //    .HasOne(c => c.SchoolSubject)
        //    .WithMany()
        //    .HasForeignKey(c => c.ClassroomSubjectId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}