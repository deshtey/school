using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;
namespace schoolapp.Infrastructure.Persistence.Configurations;
class HeadTeacherEntityConfiguration
    : IEntityTypeConfiguration<HeadTeacher>
{
    public void Configure(EntityTypeBuilder<HeadTeacher> headteacherConfiguration)
    {
        headteacherConfiguration.ToTable("headteachers", "academics");

        headteacherConfiguration
          .HasOne(h => h.Teacher)  
          .WithOne() 
          .HasForeignKey<HeadTeacher>(h => h.TeacherId) 
          .OnDelete(DeleteBehavior.Restrict);

    }
}