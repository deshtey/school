using schoolapp.Application.Common.Models;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>?> GetStudents(int schoolId);
        Task<StudentParentDto?> GetStudent(int id, int schoolId);
        Task<StudentParentDto?> PutStudent(int id, StudentParentDto Student, CancellationToken cancellationToken);
        Task<Result<Student>> CreateStudentAsync(StudentParentDto _studentParentDto, CancellationToken cancellationToken);
        Task<bool> DeleteStudent(int id, CancellationToken cancellationToken);
    }
}
