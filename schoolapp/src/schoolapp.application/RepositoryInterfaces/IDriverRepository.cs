using schoolapp.Application.Common.Models;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.RepositoryInterfaces
{
    public interface IDriverRepository
    {
        Task<SupportStaff> CreateAsync(SupportStaff driver, CancellationToken cancellationToken);
        Task<IQueryable<SupportStaff>> GetDriversAsync(CancellationToken cancellationToken);
        Task<SupportStaff> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<SupportStaff>> UpdateAsync(SupportStaff updatedDriver);
        Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}