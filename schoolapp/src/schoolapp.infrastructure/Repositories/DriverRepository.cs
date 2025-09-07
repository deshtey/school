using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Models;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;
using schoolapp.Infrastructure.Data;

namespace schoolapp.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly SchoolDbContext _context;
        public DriverRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<SupportStaff> CreateAsync(SupportStaff driver, CancellationToken cancellationToken)
        {
            await _context.SupportStaffs.AddAsync(driver, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return driver;
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _context.Update(new SupportStaff { Id = id, Status = EntityStatus.Deleted });
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

        public async Task<SupportStaff> GetByIdAsync(int id, int schoolId, CancellationToken cancellationToken)
        {
            var driver = await _context.SupportStaffs.FirstOrDefaultAsync(s => s.Id == id && s.SchoolId == schoolId, cancellationToken);
            return driver;
        }

        public async Task<IQueryable<SupportStaff>> GetDriversAsync(int schoolId, CancellationToken cancellationToken)
        {
            return _context.SupportStaffs.Where(s => s.Status == EntityStatus.Active && s.SchoolId == schoolId).AsQueryable();
        }

        public Task<Result<SupportStaff>> UpdateAsync(SupportStaff updatedDriver)
        {
            _context.Update(updatedDriver);
            _context.SaveChanges();
            return Task.FromResult(Result<SupportStaff>.Success(updatedDriver));
        }
    }
}