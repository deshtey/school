using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IClassroomStudentRepository
    {
        Task<ClassRoomStudent> CreateAsync(ClassRoomStudent classroomStudent, CancellationToken cancellationToken);
        Task<IQueryable<ClassRoomStudent>> GetClassroomStudentsAsync(CancellationToken cancellationToken);
        Task<ClassRoomStudent> GetByIdAsync(int classroomId, int studentId, CancellationToken cancellationToken);
        Task<Result<ClassRoomStudent>> UpdateAsync(ClassRoomStudent updatedClassroomStudent);
        Task<Result<bool>> DeleteAsync(int classroomId, int studentId, CancellationToken cancellationToken);
    }
}