using schoolapp.Domain.Entities.People;

namespace Studentapp.Application.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>?> GetStudents(int schoolId);
        Task<Student?> GetStudent(int id, int schoolId);
        Task<Student?> PutStudent(int id, Student Student, CancellationToken cancellationToken);
        Task<bool?> PostStudent(Student Student, CancellationToken cancellationToken);
        Task<bool> DeleteStudent(int id, CancellationToken cancellationToken);
    }
}
