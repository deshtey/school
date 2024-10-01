using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Contracts
{
    public interface IClassRoomSubjectService
    {
        Task<bool> DeleteClassRoomSubject(int id, CancellationToken cancellationToken);
        Task<ClassRoomSubjectDto?> GetClassRoomSubject(int id);
        Task<IEnumerable<ClassRoomSubjectDto>?> GetClassRoomSubjects(int classroomId);
        Task<bool?> PostClassRoomSubject(ClassRoomSubjectDto ClassRoomsubject, CancellationToken cancellationToken);
        Task<ClassRoomSubject?> PutClassRoomSubject(int id, ClassRoomSubjectDto ClassRoomsubject, CancellationToken cancellationToken);
    }
}
