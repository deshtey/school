using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class ClassRoomEntityConfiguration
    : IEntityTypeConfiguration<ClassRoom>
{
    public void Configure(EntityTypeBuilder<ClassRoom> classRoomConfiguration)
    {
        classRoomConfiguration.ToTable("classrooms", "academics");

        classRoomConfiguration.Property(s => s.ClassroomName)
            .HasColumnName("classroomname")
            .HasMaxLength(20);

        classRoomConfiguration
            .HasOne(c=>c.ClassTeacher)
            .WithMany()
            .HasForeignKey(c=>c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        classRoomConfiguration
            .HasOne(c => c.Grade)
            .WithMany(c => c.ClassRooms)
            .HasForeignKey(c => c.GradeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}