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

        classRoomConfiguration.Property(s => s.Name)
            .HasColumnName("classroomname")
            .HasMaxLength(20);

        classRoomConfiguration
            .HasOne(c=>c.ClassTeacher)
            .WithMany()
            .HasForeignKey(c=>c.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        classRoomConfiguration
            .HasOne(c => c.Grade)
            .WithMany(c => c.ClassRooms)
            .HasForeignKey(c => c.Grade.Id)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Configure new properties
        classRoomConfiguration.Property(s => s.Stream)
            .HasColumnName("stream")
            .HasMaxLength(50);

        classRoomConfiguration.Property(s => s.Building)
            .HasColumnName("building")
            .HasMaxLength(100);

        classRoomConfiguration.Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(500);
    }
}