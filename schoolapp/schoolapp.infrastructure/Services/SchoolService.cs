using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;
using schoolapp.Infrastructure.Persistence;
using schoolapp.Infrastructure.Services;

namespace schoolapp.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolDbContext _context;
        public SchoolService(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<School>?> GetSchools()
        {
            if (_context.Schools == null)
            {
                return null;
            }
            return await _context.Schools.ToListAsync();
        }

        public async Task<School?> GetSchool(int id)
        {
            if (_context.Schools == null)
            {
                return null;
            }
            var School = await _context.Schools.FindAsync(id);

            if (School == null)
            {
                return null;
            }
            return School;
        }
  
        public async Task<School?> PutSchool(int id, School School)
        {
            if (id != School.SchoolId)
            {
                return null;
            }
            _context.Entry(School).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }

        public async Task<bool?> PostSchool(School School)
        {
            if (_context.Schools == null)
            {
                return null;
            }
            _context.Schools.Add(School);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSchool(int id)
        {
            if (_context.Schools == null)
            {
                return true;
            }
            var School = await _context.Schools.FindAsync(id);
            if (School == null)
            {
                return true;
            }

            _context.Schools.Remove(School);
            await _context.SaveChangesAsync();

            return true;
        }
        private bool SchoolExists(int id)
        {
            return (_context.Schools?.Any(e => e.SchoolId == id)).GetValueOrDefault();
        }
    }
}
