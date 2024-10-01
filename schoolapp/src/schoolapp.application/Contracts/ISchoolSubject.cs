using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Application.Contracts
{
    public interface ISchoolSubjectService
    {
        Task<bool> DeleteSchoolSubject(int id, CancellationToken cancellationToken);
        Task<SchoolSubjectDto?> GetSchoolSubject(int id);
        Task<IEnumerable<SchoolSubjectDto>?> GetSchoolSubjects(int schoolId);
        Task<bool?> PostSchoolSubject(SchoolSubjectDto schoolsubject, CancellationToken cancellationToken);
        Task<SchoolSubject?> PutSchoolSubject(int id, SchoolSubjectDto schoolsubject, CancellationToken cancellationToken);
    }
}
