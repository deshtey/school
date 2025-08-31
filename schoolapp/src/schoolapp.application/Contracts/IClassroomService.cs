using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Contracts
{
    public interface IClassroomService
    {
        Task<IEnumerable<ClassRoomDto>?> GetClassRooms(int schoolId);
        Task<ClassRoomDto?> GetClassRoom(int id);
        Task<ClassRoomDto?> PutClassRoom(int id, ClassRoomDto ClassRoom, CancellationToken cancellationToken);
        Task<bool?> PostClassRoom(ClassRoomDto ClassRoom, CancellationToken cancellationToken);
        Task<bool> DeleteClassRoom(int id, CancellationToken cancellationToken);
    }
}
