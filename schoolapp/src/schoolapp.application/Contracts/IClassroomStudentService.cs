using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Contracts
{
    public interface IClassroomStudentService
    {
        Task<IEnumerable<ClassRoomStudentDto>?> GetClassRoomStudents();
        Task<ClassRoomStudentDto?> GetClassRoomStudent(int classroomId, int studentId);
        Task<ClassRoomStudentDto?> PutClassRoomStudent(int classroomId, int studentId, ClassRoomStudentDto ClassRoomStudent, CancellationToken cancellationToken);
        Task<bool?> PostClassRoomStudent(ClassRoomStudentDto ClassRoomStudent, CancellationToken cancellationToken);
        Task<bool> DeleteClassRoomStudent(int classroomId, int studentId, CancellationToken cancellationToken);
    }
}
