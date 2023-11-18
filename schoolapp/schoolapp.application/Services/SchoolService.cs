using MediatR;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities;

namespace schoolapp.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolDbContext _context;
        public SchoolService(ISchoolDbContext context)
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

        public async Task<School?> PutSchool(int id, School School, CancellationToken cancellationToken)
        {
            if (id != School.SchoolId)
            {
                return null;
            }
            var school =  await _context.Schools.FindAsync(new object[] { id }, cancellationToken);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
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

        public async Task<bool?> PostSchool(School School, CancellationToken cancellationToken)
        {
            if (_context.Schools == null)
            {
                return null;
            }
            _context.Schools.Add(School);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteSchool(int id, CancellationToken cancellationToken)
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
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        private bool SchoolExists(int id)
        {
            return (_context.Schools?.Any(e => e.SchoolId == id)).GetValueOrDefault();
        }


    }
}
