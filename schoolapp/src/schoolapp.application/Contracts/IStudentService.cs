using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentParentDto>?> GetStudents(int schoolId);
        Task<StudentParentDto?> GetStudent(int id, int schoolId);
        Task<StudentParentDto?> PutStudent(int id, StudentParentDto Student, CancellationToken cancellationToken);
        Task<Student?> PostStudent(StudentParentDto _studentParentDto, CancellationToken cancellationToken);
        Task<bool> DeleteStudent(int id, CancellationToken cancellationToken);
    }
}
