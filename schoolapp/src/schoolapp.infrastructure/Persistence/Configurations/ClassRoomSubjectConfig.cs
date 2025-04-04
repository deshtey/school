using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Academics;
using System.Reflection.Emit;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class ClassroomSubjectConfiguration
    : IEntityTypeConfiguration<ClassRoomSubject>
{
    public void Configure(EntityTypeBuilder<ClassRoomSubject> ClassroomSubjectConfig)
    {
        ClassroomSubjectConfig.ToTable("classroom_subjects", "academics");



        ClassroomSubjectConfig.HasKey(gs => new { gs.ClassRoomId, gs.SchoolSubjectId });

        ClassroomSubjectConfig
            .HasOne(gs => gs.ClassRoom)
            .WithMany()
            .HasForeignKey(gs => gs.ClassRoomId);

        ClassroomSubjectConfig
            .HasOne(gs => gs.SchoolSubject)
            .WithMany(s => s.GradeSubjects)
            .HasForeignKey(gs => gs.SchoolSubjectId);
    }
}