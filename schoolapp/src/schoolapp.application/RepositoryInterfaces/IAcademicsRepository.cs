using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IAcademicRepository
    {
        Task<AcademicYear> CreateAcademicYearWithTerms(AcademicYear academicYear, CancellationToken cancellationToken = default);
        Task<AcademicYear?> GetAcademicYearByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ClassRoom?> GetClassroomByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Grade?> GetGradeByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
