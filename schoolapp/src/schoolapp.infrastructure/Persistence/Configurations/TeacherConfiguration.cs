using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class TeacherEntityConfiguration
    : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> teacherConfiguration)
    {
        teacherConfiguration.ToTable("teachers","people");

        teacherConfiguration.Property(s => s.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100);
        teacherConfiguration.Property(s => s.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100);
        teacherConfiguration.Property(s => s.OtherNames)
            .HasColumnName("other_names")
            .HasMaxLength(100);

        teacherConfiguration.Property(s => s.Email)
            .HasColumnName("email")
            .HasMaxLength(100);

        teacherConfiguration.Property(s => s.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20);

        teacherConfiguration.Property(s => s.RegNo)
            .HasColumnName("regno")
            .HasMaxLength(20);

        teacherConfiguration
            .HasMany(s => s.Departments)
            .WithMany(s => s.Teachers)
            .UsingEntity<StaffDepartment>(
             s => s.ToTable("staff_department"));
    
        // Configure new properties
        teacherConfiguration.Property(s => s.Qualifications)
            .HasColumnName("qualifications")
            .HasMaxLength(500);

        teacherConfiguration.Property(s => s.Certifications)
            .HasColumnName("certifications")
            .HasMaxLength(500);

        teacherConfiguration.Property(s => s.SpecializationAreas)
            .HasColumnName("specialization_areas")
            .HasMaxLength(200);

        teacherConfiguration.Property(s => s.BankAccountNumber)
            .HasColumnName("bank_account_number")
            .HasMaxLength(50);

        teacherConfiguration.Property(s => s.BankName)
            .HasColumnName("bank_name")
            .HasMaxLength(100);
    }
}