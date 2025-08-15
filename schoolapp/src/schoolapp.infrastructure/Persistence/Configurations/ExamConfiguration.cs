using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Exams;

namespace schoolapp.Infrastructure.Persistence.Configurations;

class ExamEntityConfiguration
    : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> examConfiguration)
    {
        examConfiguration.ToTable("exams", "exams");

        examConfiguration.Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        examConfiguration.Property(s => s.Status)
            .HasColumnName("status");

        examConfiguration.Property(s => s.Weightage)
            .HasColumnName("weightage");

        examConfiguration.Property(s => s.PassingMarks)
            .HasColumnName("passing_marks");

        examConfiguration.Property(s => s.MaximumMarks)
            .HasColumnName("maximum_marks");

        examConfiguration.Property(s => s.StartDate)
            .HasColumnName("start_date");

        examConfiguration.Property(s => s.EndDate)
            .HasColumnName("end_date");

        examConfiguration
            .HasOne(s => s.ExamType)
            .WithMany()
            .HasForeignKey(s => s.ExamTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        examConfiguration
            .HasOne(s => s.School)
            .WithMany()
            .HasForeignKey(s => s.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}