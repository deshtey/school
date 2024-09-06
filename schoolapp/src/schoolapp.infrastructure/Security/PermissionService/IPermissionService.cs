
using Microsoft.AspNetCore.Identity;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Security.PermissionService
{
    public interface IPermissionService
    {
        Task<bool> AssignPermissionToUserAsync(string userId, string roleName);
        Task<bool> CreatePermissionAsync(string roleName);
        List<Permission> GetPermissions();
        Task<IEnumerable<string>> GetUserPermissionsAsync(string userId);
    }
}
