using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.Contracts
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>?> GetGrades(int schoolId, CancellationToken cancellationToken);
        Task<GradeDto?> GetGrade(int id);
        Task<GradeDto?> PutGrade(int id, GradeDto Grade, CancellationToken cancellationToken);
        Task<bool?> PostGrade(GradeDto Grade, CancellationToken cancellationToken);
        Task<bool> DeleteGrade(int id, CancellationToken cancellationToken);
    }
}
