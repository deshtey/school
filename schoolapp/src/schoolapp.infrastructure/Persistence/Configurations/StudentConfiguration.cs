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
        }
    }
}
