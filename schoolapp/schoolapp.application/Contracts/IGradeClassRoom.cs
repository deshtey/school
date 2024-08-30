using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IGradeClassRoomService
    {
        Task<bool> DeleteGrade(int id, CancellationToken cancellationToken);
        Task<Grade?> GetGrade(int id);
        Task<List<ClassRoom>?> GetGradeClassRooms(int GradeId);
        Task<IEnumerable<Grade>?> GetSchoolClasses(int schoolId);
        Task<List<ClassRoom>?> GetSchoolClassRooms(int SchoolId);
        Task<bool?> PostGrade(Grade Grade, CancellationToken cancellationToken);
        Task<Grade?> PutGrade(int id, Grade grade, CancellationToken cancellationToken);
    }
}
