using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class SupportSupportStaffervice : ISupportStaffService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<SupportSupportStaffervice> _logger;
        public SupportSupportStaffervice(ISchoolDbContext context, ILogger<SupportSupportStaffervice> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SupportStaff?> GetSupportStaff(int id, int schoolId)
        {
            var supportStaff = await _context.Staff.FindAsync(id);
            return supportStaff ?? null;
        }

        public async Task<IEnumerable<SupportStaff>?> GetSupportStaff(int schoolId)
        {
            var supportStaff = await _context.Staff.Where(s => s.SchoolId == schoolId).ToListAsync();
            return supportStaff;
        }

        public async Task<bool?> PostSupportStaff(SupportStaff supportStaff, CancellationToken cancellationToken)
        {
            if (_context.Staff == null)
            {
                return null;
            }
            _context.Staff.Add(supportStaff);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<SupportStaff?> PutSupportStaff(int id, SupportStaff supportStaff, CancellationToken cancellationToken)
        {
            if (supportStaff == null || id != supportStaff.Id)
            {
                return null;
            }

            try
            {
                var existingSupportStaff = await _context.Staff.FindAsync(new object[] { id }, cancellationToken);

                if (existingSupportStaff == null)
                {
                    return null; // SupportStaff with the given ID not found.
                }

                _context.Staff.Entry(existingSupportStaff).CurrentValues.SetValues(supportStaff);

                await _context.SaveChangesAsync(cancellationToken);

                return existingSupportStaff;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating supportStaff");
                return null;
            }
        }

        public async Task<bool> DeleteSupportStaff(int id, CancellationToken cancellationToken)
        {
            if (_context.Staff == null)
            {
                return false;
            }
            var SupportStaff = await _context.Staff.FindAsync(id);
            if (SupportStaff == null)
            {
                return true;
            }

            _context.Staff.Remove(SupportStaff);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public bool SupportStaffExists(int id)
        {
            return (_context.Staff?.Any(e => e.Id == id)).GetValueOrDefault();
        }   

        public async Task<bool> PostSupportStaff(List<SupportStaff> supportStaff, CancellationToken cancellationToken)
        {
            if (_context.Staff == null)
            {
                return false;
            }
            foreach (var staff in supportStaff)
            {
                _context.Staff.Add(staff);
            }
           
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
