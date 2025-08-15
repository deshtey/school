using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Contracts
{
    public interface IAcademicYearService
    {
        Task<Result<AcademicYear>> CreateAcademicYear(int schoolId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken);
        List<AcademicTerm> GenerateTerms(AcademicYear academicYear, AcademicTermType termType);
    }
}
