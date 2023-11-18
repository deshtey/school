using schoolapp.Domain.Entities;

namespace schoolapp.Application.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>?> GetSchools();
        Task<School?> GetSchool(int id);
        Task<School?> PutSchool(int id, School School, CancellationToken cancellationToken);
        Task<bool?> PostSchool(School School, CancellationToken cancellationToken);
        Task<bool> DeleteSchool(int id, CancellationToken cancellationToken);
    }
}
