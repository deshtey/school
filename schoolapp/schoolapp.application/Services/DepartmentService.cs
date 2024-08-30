using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<DepartmentService> _logger;
        public DepartmentService(ISchoolDbContext context, ILogger<DepartmentService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Department>?> GetDepartments(int schoolId)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            return await _context.Departments.Where(s => s.SchoolId == schoolId).ToListAsync();
        }

        public async Task<Department?> GetDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            var Department = await _context.Departments.FindAsync(id);

            if (Department == null)
            {
                return null;
            }
            return Department;
        }

        public async Task<Department?> PutDepartment(int id, Department school, CancellationToken cancellationToken)
        {
            if (school == null || id != school.Id)
            {
                return null;
            }

            try
            {
                var existingDepartment = await _context.Departments.FindAsync(new object[] { id }, cancellationToken);

                if (existingDepartment == null)
                {
                    return null; // Department with the given ID not found.
                }

                _context.Departments.Entry(existingDepartment).CurrentValues.SetValues(school);

                await _context.SaveChangesAsync(cancellationToken);

                return existingDepartment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostDepartment(Department Department, CancellationToken cancellationToken)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            _context.Departments.Add(Department);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken)
        {
            if (_context.Departments == null)
            {
                return false;
            }
            var Department = await _context.Departments.FindAsync(id);
            if (Department == null)
            {
                return true;
            }

            _context.Departments.Remove(Department);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
     }
}
