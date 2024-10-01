using schoolapp.Domain.Entities.ClassGrades;

namespace ClassRoomapp.Application.Contracts
{
    public interface IClassRoomService
    {
        Task<IEnumerable<ClassRoom>?> GetClassRooms(int schoolId);
        Task<ClassRoom?> GetClassRoom(int id);
        Task<ClassRoom?> PutClassRoom(int id, ClassRoom ClassRoom, CancellationToken cancellationToken);
        Task<bool?> PostClassRoom(ClassRoom ClassRoom, CancellationToken cancellationToken);
        Task<bool> DeleteClassRoom(int id, CancellationToken cancellationToken);
    }
}
