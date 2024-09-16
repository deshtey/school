using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IAuthDbContext _context;
        private readonly ILogger<PermissionService> _logger;
        public PermissionService(IAuthDbContext context, ILogger<PermissionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            if (_context .Permissions == null)
            {
                return null;
            }
            return await _context.Permissions
                
                .ToListAsync();
        }
        //public async Task<IEnumerable<Permission>?> GetPermissions(int Id)
        //{
        //    if (_context.Permissions == null)
        //    {
        //        return null;
        //    }
        //    return await _context.Permissions.Where(s => s.Id == Id)
        //        .Include(t=>t.Departments)
        //        .Select(t=>new Permission
        //        {
        //            Id = t.Id,
        //            FullName = t.GetFullName(),
        //            Salutation = t.Salutation,
        //            ImageUrl = t.Image,
        //            Email = t.Email,
        //            Gender = t.Gender,
        //            Phone   = t.Phone,
        //            SchoolId    = t.SchoolId,
        //            Status  = t.Status,
        //            RegNo = t.RegNo,
        //           // Departments = t.Departments.Select(d=>new DepartmentDto{Id=d.Id,DepartmentName=d.DepartmentName}).ToList(),
        //           // ClassRooms = t.ClassRooms.Select(c=>new ClassRoomDto{ClassRoomId=c.ClassRoomId,ClassroomName=c.ClassroomName}).ToList(),
                       
        //        })
        //        .ToListAsync();
        //}

        public async Task<Permission?> GetPermission(int id)
        {
            if (_context.Permissions == null)
            {
                return null;
            }
            var permission = await _context.Permissions.Where(t=>t.Id==id)
             
            
                .FirstOrDefaultAsync();

        
            return permission;
        }

        public async Task<Permission?> PutPermission(int id, Permission permission, CancellationToken cancellationToken)
        {
            if (permission == null || id != permission.Id)
            {
                return null;
            }

            try
            {
                var existingPermission = await _context.Permissions.FindAsync([id], cancellationToken);

                if (existingPermission == null)
                {
                    return null; // Permission with the given ID not found.
                }

                _context.Permissions.Entry(existingPermission).CurrentValues.SetValues(permission);

                await _context.SaveChangesAsync(cancellationToken);

                return existingPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating school");
                return null;
            }
        }

        public async Task<bool> PostPermission(PermissionDto permission, CancellationToken cancellationToken)
        {
            if (_context.Permissions == null)
            {
                return false;
            }
            var newPermission = new Permission
            {
                Name = permission.Name,
                Desc = permission.Desc
            };
            _context.Permissions.Add(newPermission);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeletePermission(int id, CancellationToken cancellationToken)
        {
            if (_context.Permissions == null)
            {
                return false;
            }
            var Permission = await _context.Permissions.FindAsync(id);
            if (Permission == null)
            {
                return true;
            }

            _context.Permissions.Remove(Permission);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
