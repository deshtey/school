using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Infrastructure.Persistence.Configurations;

class AcademicYearEntityConfiguration
    : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> academicYearConfiguration)
    {
        academicYearConfiguration.ToTable("academicyears", "academics");

        academicYearConfiguration.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(50);

        academicYearConfiguration.Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        academicYearConfiguration.Property(s => s.Status)
            .HasColumnName("status");

        academicYearConfiguration.Property(s => s.PrincipalRemarks)
            .HasColumnName("principalremarks")
            .HasMaxLength(1000);

        academicYearConfiguration.Property(s => s.IsCurrent)
            .HasColumnName("iscurrent");

        academicYearConfiguration.Property(s => s.StartDate)
            .HasColumnName("startdate");

        academicYearConfiguration.Property(s => s.EndDate)
            .HasColumnName("enddate");

        academicYearConfiguration
            .HasMany(s => s.Terms)
            .WithOne(s => s.AcademicYear)
            .HasForeignKey(s => s.AcademicYearId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}