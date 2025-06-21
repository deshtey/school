using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        Task<StudentParentDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Student?> GetByRegNumberAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default);
        Task<bool> RegNumberExistsAsync(string regNumber, int schoolId, CancellationToken cancellationToken = default);
        Task AddAsync(Student student, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StudentDto>> GetStudentsBySchoolId(int schoolId);
        Task<Student> UpdateStudent(StudentDto studentDto, CancellationToken cancellationToken);
    }
}
