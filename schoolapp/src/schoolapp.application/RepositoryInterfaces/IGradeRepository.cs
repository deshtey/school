using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IGradeRepository
    {
        Task<Grade> CreateAsync(Grade grade, CancellationToken cancellationToken);
        Task<IQueryable<Grade>> GetGradesAsync(CancellationToken cancellationToken);
        Task<Grade> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<Grade>> UpdateAsync(Grade updatedGrade);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}