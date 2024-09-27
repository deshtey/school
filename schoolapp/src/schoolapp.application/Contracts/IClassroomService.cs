using schoolapp.Domain.Entities.ClassGrades;

namespace Classroomapp.Application.Contracts
{
    public interface IClassroomService
    {
        Task<IEnumerable<ClassRoom>?> GetClassrooms(int schoolId);
        Task<ClassRoom?> GetClassroom(int id);
        Task<ClassRoom?> PutClassroom(int id, ClassRoom Classroom, CancellationToken cancellationToken);
        Task<bool?> PostClassroom(ClassRoom Classroom, CancellationToken cancellationToken);
        Task<bool> DeleteClassroom(int id, CancellationToken cancellationToken);
    }
}
