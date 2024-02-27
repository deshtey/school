using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>?> GetTeachers();
        Task<Teacher?> GetTeacher(int id);
        Task<Teacher?> PutTeacher(int id, Teacher Teacher, CancellationToken cancellationToken);
        Task<bool?> PostTeacher(Teacher Teacher, CancellationToken cancellationToken);
        Task<bool> DeleteTeacher(int id, CancellationToken cancellationToken);
    }
}
