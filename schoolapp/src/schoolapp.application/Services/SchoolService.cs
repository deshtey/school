using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<SchoolService> _logger;
        public SchoolService(ISchoolDbContext context, ILogger<SchoolService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<SchoolDto>?> GetSchools()
        {
            if (_context.Schools == null)
            {
                return null;
            }
            return await _context.Schools.Select(s => new SchoolDto
            {
                SchoolId = s.SchoolId,
                SchoolName = s.SchoolName,
                Country = s.Country,
                City = s.City,
                PostalCode = s.PostalCode,
                Address = s.Address,
                HomePage = s.HomePage,
                Location = s.Location,
                Phone = s.Phone,
                Region = s.Region,
                Street = s.Street,
                ZipCode = s.ZipCode,
                Active = s.Active,
               
            })
            .ToListAsync(); 
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

        public async Task<School?> PutSchool(int id, SchoolDto school, CancellationToken cancellationToken)
        {
            if (school == null || id != school.SchoolId)
            {
                return null;
            }

            try
            {
                var existingSchool = await _context.Schools.FindAsync([id], cancellationToken);

                if (existingSchool == null)
                {
                    return null; // School with the given ID not found.
                }

                _context.Schools.Entry(existingSchool).CurrentValues.SetValues(school);

                await _context.SaveChangesAsync(cancellationToken);

                return existingSchool;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostSchool(SchoolDto _school, CancellationToken cancellationToken)
        {
            if (_context.Schools == null)
            {
                return null;
            }
            var school = new School
            {
                Street = _school.Street,
                City = _school.City,                    
                PostalCode = _school.PostalCode,
                Country = _school.Country,
                Address = _school.Address,
                Email = _school.Email,
                Phone = _school.Phone,
                Region = _school.Region,
                SchoolName = _school.SchoolName,
                Logo = _school.LogoUrl,
                HomePage = _school.HomePage,
                Location = _school.Location,
                ZipCode = _school.ZipCode,
                Active=true
                  
            };
            _context.Schools.Add(school);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteSchool(int id, CancellationToken cancellationToken)
        {
            if (_context.Schools == null)
            {
                return false;
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
