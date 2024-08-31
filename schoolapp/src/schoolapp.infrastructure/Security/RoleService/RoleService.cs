using Microsoft.AspNetCore.Identity;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.RoleService;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    // Methods to manage roles
    public async Task<bool> CreateRoleAsync(string roleName)
    {
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (roleExists)
            return false;

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        return result.Succeeded;
    }
    public List<IdentityRole> GetRoles()
    {
        var roles = _roleManager.Roles.ToList();
        return roles;
    }
    public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return Enumerable.Empty<string>();

        var userRoles = await _userManager.GetRolesAsync(user);
        return userRoles;
    }
    public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            return false;

        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }

}