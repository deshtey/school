using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class GradeEntityConfiguration
    : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> gradeConfiguration)
    {
        gradeConfiguration.ToTable("grades");

        //gradeConfiguration
        //    .OwnsOne(o => o.GradeAddress);

        gradeConfiguration.Property(s => s.Name)
            .HasColumnName("gradename")
            .HasMaxLength(20);

        gradeConfiguration.Property(s => s.Desc)
         .HasColumnName("desc")
         .HasMaxLength(100);

        gradeConfiguration
            .HasMany(s => s.ClassRooms)
            .WithOne(s => s.Grade)
            .HasForeignKey(s => s.GradeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}