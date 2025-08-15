using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Models;
using schoolapp.Application.Contracts;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly ILogger<AcademicYearService> _logger;
        private readonly IAcademicRepository _academicRepository;
        public AcademicYearService(IAcademicRepository academicRepository, ILogger<AcademicYearService> logger)
        {
            _academicRepository = academicRepository;
            _logger = logger;
        }
        public async Task<Result<AcademicYear>> CreateAcademicYear(int schoolId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            try
            {
                var acaYear = AcademicYear.CreateWithTerms(schoolId, startDate, endDate, AcademicTermType.Trimester);
                var res = await _academicRepository.CreateAcademicYearWithTerms(acaYear, cancellationToken);
                return Result<AcademicYear>.Success(res);
            }
            catch (Exception ex)
            {
                return Result<AcademicYear>.Failure(["Error creating academic year: " + ex.Message]);
            }
        }

        public List<AcademicTerm> GenerateTerms(AcademicYear academicYear, AcademicTermType termType)
        {
            return termType switch
            {
                AcademicTermType.Semester => GenerateSemesterTerms(academicYear),
                AcademicTermType.Trimester => GenerateTrimesterTerms(academicYear),
                AcademicTermType.Quarter => GenerateQuarterTerms(academicYear),
                _ => throw new ArgumentException($"Unsupported term type: {termType}")
            };
        }

        private List<AcademicTerm> GenerateSemesterTerms(AcademicYear academicYear)
        {
            var terms = new List<AcademicTerm>();
            var yearSpan = academicYear.EndDate.DayNumber - academicYear.StartDate.DayNumber;
            var semesterDays = yearSpan / 2;

            // First Semester
            var firstSemesterEnd = academicYear.StartDate.AddDays(semesterDays);
            terms.Add(new AcademicTerm($"First Semester {academicYear.StartDate.Year}",
                academicYear.StartDate,
                firstSemesterEnd,academicYear));

            // Second Semester
            terms.Add(new AcademicTerm($"Second Semester {academicYear.StartDate.Year}",
                firstSemesterEnd.AddDays(1),
                academicYear.EndDate, academicYear));

            return terms;
        }

        private List<AcademicTerm> GenerateTrimesterTerms(AcademicYear academicYear)
        {
            var terms = new List<AcademicTerm>();
            var yearSpan = academicYear.EndDate.DayNumber - academicYear.StartDate.DayNumber;
            var trimesterDays = yearSpan / 3;

            for (int i = 0; i < 3; i++)
            {
                var termStart = academicYear.StartDate.AddDays(i * trimesterDays);
                var termEnd = i == 2 ? academicYear.EndDate : academicYear.StartDate.AddDays((i + 1) * trimesterDays - 1);

                terms.Add(new AcademicTerm($"{GetOrdinal(i + 1)} Trimester {academicYear.StartDate.Year}",
                    termStart,
                    termEnd,academicYear
                    ));
            }

            return terms;
        }

        private List<AcademicTerm> GenerateQuarterTerms(AcademicYear academicYear)
        {
            var terms = new List<AcademicTerm>();
            var yearSpan = academicYear.EndDate.DayNumber - academicYear.StartDate.DayNumber;
            var quarterDays = yearSpan / 4;

            for (int i = 0; i < 4; i++)
            {
                var termStart = academicYear.StartDate.AddDays(i * quarterDays);
                var termEnd = i == 3 ? academicYear.EndDate : academicYear.StartDate.AddDays((i + 1) * quarterDays - 1);

                terms.Add(new AcademicTerm($"{GetOrdinal(i + 1)} Quarter {academicYear.StartDate.Year}",
                    termStart,
                    termEnd, academicYear));
            }

            return terms;
        }

        private string GetOrdinal(int number) => number switch
        {
            1 => "First",
            2 => "Second",
            3 => "Third",
            4 => "Fourth",
            _ => $"{number}th"
        };
    }


}
