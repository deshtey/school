using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Contracts
{
    public interface IStudentSubjectService
    {
        Task<bool> DeleteStudentSubject(int id, CancellationToken cancellationToken);
        Task<StudentSubjectDto?> GetStudentSubject(int id);
        Task<IEnumerable<StudentSubjectDto>?> GetStudentSubjects(int studentId);
        Task<bool?> PostStudentSubject(StudentSubjectDto StudentSubject, CancellationToken cancellationToken);
        Task<StudentSubject?> PutStudentSubject(int id, StudentSubjectDto StudentSubject, CancellationToken cancellationToken);
    }
}
