using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Contracts
{
    public interface IClassroomService
    {
        Task<IEnumerable<ClassRoom>?> GetClassRooms(int schoolId);
        Task<ClassRoom?> GetClassRoom(int id, int schoolId);
        Task<ClassRoom?> PutClassRoom(int id, ClassRoom ClassRoom, int schoolId, CancellationToken cancellationToken);
        Task<bool?> PostClassRoom(ClassRoom ClassRoom, CancellationToken cancellationToken);
        Task<bool> DeleteClassRoom(int id, CancellationToken cancellationToken);
    }
}
