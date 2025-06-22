

using schoolapp.Application.Common.Models;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface ISchoolRepository
    {
        Task<School> CreateAsync(School school, CancellationToken cancellationToken);
        Task<IQueryable<School>> GetSchoolsAsync(CancellationToken cancellationToken);
        Task<School> GetByIdAsync(int schoolId, CancellationToken cancellationToken);
        Task<School> GetByNameAsync(string schoolName, CancellationToken cancellationToken);
        Task<Result<School>> UpdateAsync(School updatedSchool);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
