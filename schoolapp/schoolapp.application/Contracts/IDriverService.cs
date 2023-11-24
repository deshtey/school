using schoolapp.Domain.Entities.People;

namespace Driverapp.Application.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>?> GetDrivers();
        Task<Driver?> GetDriver(int id);
        Task<Driver?> PutDriver(int id, Driver Driver, CancellationToken cancellationToken);
        Task<bool?> PostDriver(Driver Driver, CancellationToken cancellationToken);
        Task<bool> DeleteDriver(int id, CancellationToken cancellationToken);
    }
}
