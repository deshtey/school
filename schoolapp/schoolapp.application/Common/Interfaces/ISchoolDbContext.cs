using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Common.Interfaces
{
    public interface ISchoolDbContext
    {
        DbSet<School> Schools { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Parent> Parents { get; set; }
        DbSet<SupportStaff> Staff { get; set; }
        DbSet<ClassRoom> ClassRooms { get; }
       // DbSet<ClassRoomStudent> ClassRoomStudents { get; }
        DbSet<Exam> Exams { get; }
        DbSet<ExamType> ExamTypes { get; }
        DbSet<Grade> Grades { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);   
    }
}
