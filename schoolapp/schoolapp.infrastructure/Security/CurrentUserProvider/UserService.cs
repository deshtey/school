using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Security.CurrentUserProvider;

namespace schoolapp.Infrastructure.Security.CurrentUserProvider;

public class UserService : IUserService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    public UserService(RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<IEnumerable<string>> GetRolesAsync()
    {
        return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
    }

}