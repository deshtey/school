using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using schoolapp.Infrastructure.Identity;
using System.Threading;

namespace schoolapp.Infrastructure.Security.RoleService;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<RoleService> _logger;
    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, ILogger<RoleService> logger)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _logger = logger;
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

        var role = await _roleManager.FindByIdAsync(roleName);
        if (role == null)
            return false;

        var result = await _userManager.AddToRoleAsync(user, role.Name);
        return result.Succeeded;
    }
    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    } 
    public async Task<bool> DeleteRole(string roleId)
    {
        try
        {

 
        var _role = await _roleManager.FindByIdAsync(roleId);
        if (_role == null)
        {
            return true;
        }
        await _roleManager.DeleteAsync(_role);   

        return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

}