using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Infrastructure.Persistence.Configurations;

class AcademicTermEntityConfiguration
    : IEntityTypeConfiguration<AcademicTerm>
{
    public void Configure(EntityTypeBuilder<AcademicTerm> academicTermConfiguration)
    {
        academicTermConfiguration.ToTable("academictermtypes", "academics");

        academicTermConfiguration.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(100);

        academicTermConfiguration.Property(s => s.StartDate)
            .HasColumnName("startdate");

        academicTermConfiguration.Property(s => s.EndDate)
            .HasColumnName("enddate");

        academicTermConfiguration
            .HasOne(s => s.AcademicYear)
            .WithMany(s => s.Terms)
            .HasForeignKey(s => s.AcademicYearId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}