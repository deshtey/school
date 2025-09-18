using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ILogger<DriverService> _logger;
        public DriverService(ILogger<DriverService> logger, IDriverRepository driverRepository)
        {
            _logger = logger;
            _driverRepository = driverRepository;
        }

        public async Task<bool> DeleteDriver(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _driverRepository.DeleteAsync(id, cancellationToken);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Deleted driver with ID: {Id}", id);
                    return true;
                }
                _logger.LogError("Failed to delete driver with ID: {Id}", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting driver");
                return false;
            }
        }

        public async Task<SupportStaff?> GetDriver(int id, int schoolId)
        {
            try
            {
                var driver = await _driverRepository.GetByIdAsync(id, schoolId, CancellationToken.None);
                return driver;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching driver");
                return null;
            }
        }

        public async Task<IEnumerable<SupportStaff>?> GetDrivers(int schoolId)
        {
            try
            {
                var driversQuery = await _driverRepository.GetDriversAsync(schoolId, CancellationToken.None);
                var drivers = await driversQuery.ToListAsync();
                return drivers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching drivers");
                return null;
            }
        }

        public async Task<bool?> PostDriver(SupportStaff Driver, CancellationToken cancellationToken)
        {
            try
            {
                var created = await _driverRepository.CreateAsync(Driver, cancellationToken);
                _logger.LogInformation("Created driver with ID: {Id}", created.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating driver");
                return false;
            }
        }

        public Task<bool?> PostDriver(SupportStaffDto Driver, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<SupportStaff?> PutDriver(int id, SupportStaff driver, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _driverRepository.GetByIdAsync(id, driver.SchoolId, cancellationToken);
                if (existing == null)
                {
                    _logger.LogWarning("Driver with ID: {Id} not found", id);
                    return null;
                }
                driver.Id = id;
                var result = await _driverRepository.UpdateAsync(driver);
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Updated driver with ID: {Id}", id);
                    return result.Value;
                }
                _logger.LogError("Failed to update driver with ID: {Id}", id);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating driver");
                return null;
            }
        }

        public Task<SupportStaffDto?> PutDriver(int id, SupportStaffDto Driver, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<SupportStaffDto?> IDriverService.GetDriver(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SupportStaffDto>?> IDriverService.GetDrivers()
        {
            throw new NotImplementedException();
        }
    }
}