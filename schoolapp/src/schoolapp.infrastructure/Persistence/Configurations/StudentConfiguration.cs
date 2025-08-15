using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> studentConfiguration)
        {
            studentConfiguration.ToTable("students", "people");

            //studentConfiguration
            //    .OwnsOne(o => o.StudentAddress);

            
            studentConfiguration
                .HasOne(s=>s.ClassRoom)
                .WithMany(o=>o.Students)
                .HasForeignKey(s=>s.ClassRoomId)
                .OnDelete(DeleteBehavior.Restrict);

            studentConfiguration
                .HasMany(s => s.Parents)
                .WithMany(s => s.Students)
                .UsingEntity<StudentParent>(
                    s => s.ToTable("student_parent"));
                    
            // Configure new properties
            studentConfiguration.Property(s => s.EmergencyContactName)
                .HasColumnName("emergency_contact_name")
                .HasMaxLength(100);

            studentConfiguration.Property(s => s.EmergencyContactPhone)
                .HasColumnName("emergency_contact_phone")
                .HasMaxLength(20);

            studentConfiguration.Property(s => s.EmergencyContactRelationship)
                .HasColumnName("emergency_contact_relationship")
                .HasMaxLength(50);

            studentConfiguration.Property(s => s.MedicalConditions)
                .HasColumnName("medical_conditions")
                .HasMaxLength(500);

            studentConfiguration.Property(s => s.Allergies)
                .HasColumnName("allergies")
                .HasMaxLength(500);

            studentConfiguration.Property(s => s.BloodGroup)
                .HasColumnName("blood_group")
                .HasMaxLength(10);

            studentConfiguration.Property(s => s.Religion)
                .HasColumnName("religion")
                .HasMaxLength(50);

            studentConfiguration.Property(s => s.Nationality)
                .HasColumnName("nationality")
                .HasMaxLength(50);

            studentConfiguration.Property(s => s.PreviousSchool)
                .HasColumnName("previous_school")
                .HasMaxLength(200);
        }
    }
}
