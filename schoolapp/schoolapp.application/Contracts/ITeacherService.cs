using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface ITeacherService
    {
        Task<bool> DeleteTeacher(int id, CancellationToken cancellationToken);
        Task<TeacherDto?> GetTeacher(int id);
        Task<IEnumerable<TeacherDto>?> GetTeachers(int schoolId);
        Task<bool?> PostTeacher(TeacherDto teacher, CancellationToken cancellationToken);
        Task<Teacher?> PutTeacher(int id, TeacherDto teacher, CancellationToken cancellationToken);
    }
}
