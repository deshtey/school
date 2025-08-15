using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Exams;

namespace schoolapp.Infrastructure.Persistence.Configurations;

class ExamTypeEntityConfiguration
    : IEntityTypeConfiguration<ExamType>
{
    public void Configure(EntityTypeBuilder<ExamType> examTypeConfiguration)
    {
        examTypeConfiguration.ToTable("examtypes", "exams");

        examTypeConfiguration.Property(s => s.Desc)
            .HasColumnName("desc")
            .HasMaxLength(100);

        examTypeConfiguration
            .HasOne(s => s.School)
            .WithMany()
            .HasForeignKey(s => s.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}