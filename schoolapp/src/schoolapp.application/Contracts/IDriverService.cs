using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<SupportStaffDto>?> GetDrivers();
        Task<SupportStaffDto?> GetDriver(int id);
        Task<SupportStaffDto?> PutDriver(int id, SupportStaffDto Driver, CancellationToken cancellationToken);
        Task<bool?> PostDriver(SupportStaffDto Driver, CancellationToken cancellationToken);
        Task<bool> DeleteDriver(int id, CancellationToken cancellationToken);
    }
}
