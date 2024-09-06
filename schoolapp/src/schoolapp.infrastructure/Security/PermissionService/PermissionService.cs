using Microsoft.AspNetCore.Identity;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities.Other;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.PermissionService;

public class PermissionService : IPermissionService
{
    private readonly ISchoolDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    public PermissionService(UserManager<AppUser> userManager, ISchoolDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public Task<bool> AssignPermissionToUserAsync(string userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreatePermissionAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public List<Permission> GetPermissions()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetUserPermissionsAsync(string userId)
    {
        throw new NotImplementedException();
    }

    // Methods to manage roles


}