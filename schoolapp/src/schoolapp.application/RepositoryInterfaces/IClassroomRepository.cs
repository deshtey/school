using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IClassroomRepository
    {
        Task<ClassRoom> CreateAsync(ClassRoom classroom, CancellationToken cancellationToken);
        Task<IQueryable<ClassRoom>> GetClassroomsAsync(int schoolId, CancellationToken cancellationToken);
        Task<ClassRoom> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<ClassRoom>> UpdateAsync(ClassRoom updatedClassroom);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}