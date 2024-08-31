using schoolapp.Domain.Entities.ClassGrades;

namespace Gradeapp.Application.Contracts
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>?> GetGrades();
        Task<Grade?> GetGrade(int id);
        Task<Grade?> PutGrade(int id, Grade Grade, CancellationToken cancellationToken);
        Task<bool?> PostGrade(Grade Grade, CancellationToken cancellationToken);
        Task<bool> DeleteGrade(int id, CancellationToken cancellationToken);
    }
}
