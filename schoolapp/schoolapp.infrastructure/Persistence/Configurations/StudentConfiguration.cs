using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> studentConfiguration)
        {
            studentConfiguration.ToTable("students");

            studentConfiguration
                .OwnsOne(o => o.StudentAddress);

            studentConfiguration.HasOne<ClassRoom>()
                .WithMany()
                .HasForeignKey(o => o.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
