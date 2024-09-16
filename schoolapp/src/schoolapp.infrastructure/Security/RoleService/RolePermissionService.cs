//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using schoolapp.Domain.Entities.Other;
//using schoolapp.Infrastructure.Identity;
//using System.Threading;

//namespace schoolapp.Infrastructure.Security.RolePermissionService;

//public class RolePermissionService : IRolePermissionService
//{
//    private readonly RoleManager<AppRole> _rolepermissionManager;
//    private readonly UserManager<AppUser> _userManager;
//    public RolePermissionService(RoleManager<AppRole>  roleManager, UserManager<AppUser> userManager)
//    {
//        _rolepermissionManager = roleManager;
//        _userManager = userManager;
//    }

//    public async Task<bool> AssignRolePermissionToRoleAsync(string roleId, string permissionName)
//    {

//        if (_context.Permissions == null)
//        {
//            return false;
//        }
//        var newPermission = new Permission
//        {
//            Name = permission.Name,
//            Desc = permission.Desc
//        };
//        _context.Permissions.Add(newPermission);
//        await _context.SaveChangesAsync(cancellationToken);

//        return true; return result.Succeeded;
//    }

//}