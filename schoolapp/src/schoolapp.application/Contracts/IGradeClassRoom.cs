using schoolapp.Application.DTOs;

namespace schoolapp.Application.Contracts
{
    public interface IGradeClassRoomService
    {
        Task<bool> DeleteGrade(int id, CancellationToken cancellationToken);
        Task<ClassRoomDto?> GetClassRoom(int id);
        Task<GradeDto?> GetGrade(int id);
        Task<List<ClassRoomDto>?> GetGradeClassRooms(int GradeId);
        Task<IEnumerable<GradeDto>?> GetSchoolClasses(int schoolId);
        Task<List<ClassRoomDto>?> GetSchoolClassRooms(int SchoolId);
        Task<bool?> PostClassroom(ClassRoomDto classRoom, CancellationToken cancellationToken);
        Task<bool?> PostGrade(GradeDto grade, CancellationToken cancellationToken);
        Task<ClassRoomDto?> PutClassroom(int id, ClassRoomDto classRoom, CancellationToken cancellationToken);
        Task<GradeDto?> PutGrade(int id, GradeDto grade, CancellationToken cancellationToken);
        Task<bool> DeleteClassroom(int id, CancellationToken cancellationToken);
    }
}
