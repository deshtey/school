
using Microsoft.AspNetCore.Identity;

namespace schoolapp.Infrastructure.Security.RoleService
{
    public interface IRoleService
    {
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRole(string roleId);
        List<IdentityRole> GetRoles();
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
