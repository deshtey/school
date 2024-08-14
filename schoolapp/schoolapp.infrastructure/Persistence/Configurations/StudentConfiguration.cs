using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;
using System.Reflection.Emit;

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
            studentConfiguration
                .HasMany(s => s.Parents)
                .WithMany(s => s.Students)
                .UsingEntity<StudentParent>(
                    s => s.ToTable("student_parent"));
        }
    }
}
