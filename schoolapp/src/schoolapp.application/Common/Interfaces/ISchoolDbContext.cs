using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Common.Interfaces
{
    public interface ISchoolDbContext:IDisposable
    {
        DbSet<School> Schools { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Parent> Parents { get; set; }
        DbSet<SupportStaff> SupportStaffs { get; set; }
        DbSet<ClassRoom> ClassRooms { get; }
        DbSet<StudentParent> StudentParents { get; }

        DbSet<Grade> Grades { get; }
        DbSet<Department> Departments { get; set; }
        DbSet<ClassRoomSubject> ClassRoomSubjects { get; set; }
        DbSet<SchoolSubject> SchoolSubjects { get; set; }
        DbSet<StudentSubject> StudentSubjects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        //  transaction support
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
