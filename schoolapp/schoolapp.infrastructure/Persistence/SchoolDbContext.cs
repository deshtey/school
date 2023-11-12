using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Entities.People;
using schoolapp.Infrastructure.Identity;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace schoolapp.Infrastructure.Data;

public class SchoolDbContext : IdentityDbContext<SchoolUser>,ISchoolDbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<School> Schools => Set<School>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Parent> Parents => Set<Parent>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamType> ExamTypes => Set<ExamType>();
    public DbSet<ClassRoom> ClassRooms => Set<ClassRoom>();
    public DbSet<ClassRoomStudent> ClassRoomStudents => Set<ClassRoomStudent>();
    public DbSet<Grade> Grades => Set<Grade>();

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        builder.Entity<School>()
    .ToTable("schools", schema: "school");

    }
}
