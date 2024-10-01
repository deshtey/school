using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class SchoolSubjectConfiguration
    : IEntityTypeConfiguration<SchoolSubject>
{
    public void Configure(EntityTypeBuilder<SchoolSubject> SchoolSubjectConfiguration)
    {
        SchoolSubjectConfiguration.ToTable("school_subjects", "academics");

        SchoolSubjectConfiguration.Property(s => s.SubjectName)
            .HasColumnName("subject_name")
            .HasMaxLength(100);

        SchoolSubjectConfiguration.Property(s => s.Desc)
            .HasColumnName("desc")
            .HasMaxLength(100);

        SchoolSubjectConfiguration
            .HasOne(s=>s.School)
            .WithMany()
            .HasForeignKey(s=>s.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);  
    }
}