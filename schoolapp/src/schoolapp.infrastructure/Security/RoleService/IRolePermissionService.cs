
using Microsoft.AspNetCore.Identity;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Security.RolePermissionService
{
    public interface IRolePermissionService
    {
        Task<bool> AssignRolePermissionToUserAsync(string userId, string rolepermissionName);
        Task<bool> CreateRolePermissionAsync(string rolepermissionName);
        List<RolePermission> GetRolePermissions();
        Task<IEnumerable<string>> GetUserRolePermissionsAsync(string userId);
    }
}
