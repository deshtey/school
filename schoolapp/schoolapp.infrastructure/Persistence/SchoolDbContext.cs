using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Entities.People;
using schoolapp.Infrastructure.Identity;
using System.Reflection.Emit;
namespace schoolapp.Infrastructure.Data;

public class SchoolDbContext : IdentityDbContext<SchoolUser>, ISchoolDbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<SupportStaff> Staff { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamType> ExamTypes { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    //public DbSet<ClassRoomStudent> ClassRoomStudents { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        builder.HasDefaultSchema("school");

        builder.Entity<School>()
        .ToTable("schools", schema: "school");
        builder.Entity<Student>()
    .ToTable("students", schema: "school");
        builder.Entity<Teacher>()
    .ToTable("teachers", schema: "school");
        builder.Entity<Parent>()
    .ToTable("parents", schema: "school");
        builder.Entity<SupportStaff>()
    .ToTable("supportstaffs", schema: "school");
        builder.Entity<Exam>()
    .ToTable("exams", schema: "school");
        builder.Entity<ExamType>()
    .ToTable("examtypes", schema: "school");
        builder.Entity<ClassRoom>()
    .ToTable("classrooms", schema: "school");
        builder.Entity<Grade>()
    .ToTable("grades", schema: "school");

        //builder.Entity<Student>()
        //.HasOne(s => s.StudentClass)
        //.WithOne(s => s.Student)
        //.HasForeignKey<ClassRoomStudent>(c => c.StudentId);

    }
}
