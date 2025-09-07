using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Contracts
{
    public interface IClassroomStudentService
    {
        Task<bool> DeleteClassRoomStudent(int classroomId, int studentId, CancellationToken cancellationToken);
        Task<ClassRoomStudent?> GetClassRoomStudent(int classroomId, int studentId, int schoolId);
        Task<IEnumerable<ClassRoomStudent>?> GetClassRoomStudents();
        Task<IEnumerable<ClassRoomStudent>?> GetClassRoomStudents(int schoolId, int classroomId);
        Task<bool?> PostClassRoomStudent(ClassRoomStudent ClassRoomStudent, CancellationToken cancellationToken);
        Task<ClassRoomStudent?> PutClassRoomStudent(int classroomId, int studentId, ClassRoomStudentDto classRoomStudentDto, CancellationToken cancellationToken);
    }
}
