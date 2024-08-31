using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
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
        public async Task<IEnumerable<DepartmentDto>?> GetDepartments(int schoolId)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            return await _context.Departments.Where(s => s.SchoolId == schoolId)
                .Select(t => new DepartmentDto
                {
                    Id = t.Id,
                    DepartmentName = t.DepartmentName,
                    DepartmentHead = t.DepartmentHead,
                    SchoolId = t.SchoolId
                    
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto?> GetDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            var Department = await _context.Departments.Where(t => t.Id == id)
                .Select(t => new DepartmentDto
                {
                    Id = t.Id,
                    DepartmentName = t.DepartmentName,
                    DepartmentHead = t.DepartmentHead,
                    SchoolId = t.SchoolId
                }).FirstOrDefaultAsync();

            if (Department == null)
            {
                return null;
            }
            return Department;
        }

        public async Task<Department?> PutDepartment(int id, DepartmentDto department, CancellationToken cancellationToken)
        {
            if (department == null || id != department.Id)
            {
                return null;
            }

            try
            {
                var existingDepartment = await _context.Departments.FindAsync([id], cancellationToken);

                if (existingDepartment == null)
                {
                    return null; // Department with the given ID not found.
                }

                _context.Departments.Entry(existingDepartment).CurrentValues.SetValues(department);

                await _context.SaveChangesAsync(cancellationToken);

                return existingDepartment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostDepartment(DepartmentDto department, CancellationToken cancellationToken)
        {
            if (_context.Departments == null)
            {
                return null;
            }
            Department newDepartment = new Department
            {
                DepartmentName = department.DepartmentName,
                DepartmentHead = department.DepartmentHead,
                SchoolId = department.SchoolId
            };
            _context.Departments.Add(newDepartment);
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
