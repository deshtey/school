using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IAcademicRepository
    {
        Task<AcademicYear?> GetAcademicYearByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Grade?> GetGradeByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
