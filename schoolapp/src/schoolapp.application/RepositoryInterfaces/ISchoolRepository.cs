

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface ISchoolRepository
    {
        Task<School> CreateAsync(School school, CancellationToken cancellationToken);
        Task<IQueryable<School>> GetAllSchoolsAsync(CancellationToken cancellationToken);
        Task<School> GetByIdAsync(int schoolId, CancellationToken cancellationToken);
        Task<School> GetByNameAsync(string schoolName, CancellationToken cancellationToken);
    }
}
