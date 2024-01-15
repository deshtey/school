using schoolapp.Domain.Entities.People;

namespace Driverapp.Application.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<SupportStaff>?> GetDrivers();
        Task<SupportStaff?> GetDriver(int id);
        Task<SupportStaff?> PutDriver(int id, SupportStaff Driver, CancellationToken cancellationToken);
        Task<bool?> PostDriver(SupportStaff Driver, CancellationToken cancellationToken);
        Task<bool> DeleteDriver(int id, CancellationToken cancellationToken);
    }
}
