using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class ClassroomSubjectConfiguration
    : IEntityTypeConfiguration<ClassRoomSubject>
{
    public void Configure(EntityTypeBuilder<ClassRoomSubject> ClassroomSubjectConfig)
    {
        ClassroomSubjectConfig.ToTable("classroom_subjects", "academics");

        ClassroomSubjectConfig.Property(s => s.SubjectName)
            .HasColumnName("subject_name")
            .HasMaxLength(100);

        ClassroomSubjectConfig
            .HasOne(c=>c.ClassRoom)
            .WithMany()
            .HasForeignKey(c=>c.ClassRoomId)
            .OnDelete(DeleteBehavior.Cascade);

        ClassroomSubjectConfig
            .HasOne(c => c.SchoolSubject)
            .WithMany()
            .HasForeignKey(c => c.SchoolSubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}