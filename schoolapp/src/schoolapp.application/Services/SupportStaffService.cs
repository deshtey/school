using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Services
{
    public class SupportStaffService : ISupportStaffService
    {
        private readonly ISchoolDbContext _context;
        private readonly ILogger<SupportStaffService> _logger;
        public SupportStaffService(ISchoolDbContext context, ILogger<SupportStaffService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<SupportStaffDto>?> GetSupportStaffs(int schoolId)
        {
            if (_context.SupportStaffs == null)
            {
                return null;
            }
            return await _context.SupportStaffs.Where(s => s.SchoolId == schoolId)
                .Include(t => t.Departments)
                .Select(t => new SupportStaffDto
                {
                    FullName = t.GetFullName(),
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone = t.Phone,
                    SchoolId = t.SchoolId,
                    Status = t.Status.ToString(),
                    StaffNumber = t.StaffNumber                
                    // Departments = t.Departments.Select(d=>new DepartmentDto{Id=d.Id,DepartmentName=d.DepartmentName}).ToList(),
                    // ClassRooms = t.ClassRooms.Select(c=>new ClassRoomDto{ClassRoomId=c.ClassRoomId,ClassroomName=c.ClassroomName}).ToList(),

                })
                .ToListAsync();
        }

        public async Task<SupportStaffDto?> GetSupportStaff(int id)
        {
            if (_context.SupportStaffs == null)
            {
                return null;
            }
            var SupportStaff = await _context.SupportStaffs.Where(t => t.Id == id)
                .Include(t => t.Departments)
                .Select(t => new SupportStaffDto
                {
                    FullName = t.GetFullName(),
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    OtherName = t.OtherNames,
                    DOB = t.DOB,
                    Image = t.Image,
                    Salutation = t.Salutation,
                    Email = t.Email,
                    Gender = t.Gender,
                    Phone = t.Phone,
                    SchoolId = t.SchoolId,
                    Status = t.Status.ToString(),
                    StaffNumber  = t.StaffNumber, 
                    Departments = t.Departments.Select(d => new DepartmentDto { Id = d.Id, DepartmentName = d.DepartmentName }).ToList(),

                })
                .FirstOrDefaultAsync();


            return SupportStaff;
        }

        public async Task<SupportStaff?> PutSupportStaff(int id, SupportStaffDto SupportStaff, CancellationToken cancellationToken)
        {
            if (SupportStaff == null || id != SupportStaff.Id)
            {
                return null;
            }

            try
            {
                var existingSupportStaff = await _context.SupportStaffs.FindAsync([id], cancellationToken);

                if (existingSupportStaff == null)
                {
                    return null; // SupportStaff with the given ID not found.
                }

                _context.SupportStaffs.Entry(existingSupportStaff).CurrentValues.SetValues(SupportStaff);

                await _context.SaveChangesAsync(cancellationToken);

                return existingSupportStaff;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool?> PostSupportStaff(SupportStaffDto SupportStaff, CancellationToken cancellationToken)
        {
            if (_context.SupportStaffs == null)
            {
                return null;
            }
            var newSupportStaff = new SupportStaff
            {
                SchoolId = SupportStaff.SchoolId,
                FirstName = SupportStaff.FirstName,
                LastName = SupportStaff.LastName,
                OtherNames = SupportStaff.OtherName,
                Salutation = SupportStaff.Salutation,               
                DOB = SupportStaff.DOB,
                Email = SupportStaff.Email,
                Gender = SupportStaff.Gender,
                Image = SupportStaff.Image,
                Phone = SupportStaff.Phone

            };
            _context.SupportStaffs.Add(newSupportStaff);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteSupportStaff(int id, CancellationToken cancellationToken)
        {
            if (_context.SupportStaffs == null)
            {
                return false;
            }
            var SupportStaff = await _context.SupportStaffs.FindAsync(id);
            if (SupportStaff == null)
            {
                return true;
            }

            _context.SupportStaffs.Remove(SupportStaff);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
