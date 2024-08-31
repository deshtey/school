//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using schoolapp.Domain.Entities.People;


//namespace schoolapp.Infrastructure.Persistence.Configurations;
//class StudentParentConfiguration
//    : IEntityTypeConfiguration<StudentParent>
//{
//    public void Configure(EntityTypeBuilder<StudentParent> schoolConfiguration)
//    {
//        schoolConfiguration.ToTable("student_parents");

//        schoolConfiguration.HasKey(sp => new { sp.StudentId, sp.ParentId });

//        //schoolConfiguration.HasOne(sp => sp.Student)
//        //  .WithMany(s => s.StudentParents)
//        //  .HasForeignKey(sp => sp.StudentId)
//        //  .OnDelete(DeleteBehavior.Cascade);

//        //schoolConfiguration.HasOne(sp => sp.Parent)
//        //      .WithMany(p => p.StudentParents)
//        //      .HasForeignKey(sp => sp.ParentId)
//        //      .OnDelete(DeleteBehavior.Cascade);

//    }
//}