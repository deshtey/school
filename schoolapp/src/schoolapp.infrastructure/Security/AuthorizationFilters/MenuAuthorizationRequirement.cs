using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using schoolapp.Infrastructure.Data;
using schoolapp.Infrastructure.Identity;
using System.Threading.Tasks;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    
    private readonly IServiceProvider _serviceProvider;
    public PermissionHandler( IServiceProvider serviceProvider)
    {

        _serviceProvider = serviceProvider;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
        var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        if (!context.User.Identity.IsAuthenticated)
        {
            return;
        }
        var user = await _userManager.GetUserAsync(context.User);
        if (user == null)
        {
            return;
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var hasAccess = await dbContext.RolePermissions
            .AnyAsync(rmp => userRoles.Contains(rmp.RoleId) && rmp.Permission.Name == requirement.Permission);

        if (hasAccess)
        {
            context.Succeed(requirement);
        }
        //var role = _userManager.GetRolesAsync(context.User).Result.FirstOrDefault();
        //var userId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //var hasPermission = await _context.UserPermissions
        //    .AnyAsync(up => up.UserId == userId && up.Permission.Name == requirement.Permission);

        //if (hasPermission)
        //{
        //    context.Succeed(requirement);
        //}
    }
}

public class PermissionPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly IServiceProvider _serviceProvider;

    public PermissionPolicyProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();

        var permission = await dbContext.Permissions.FirstOrDefaultAsync(p => p.Name == policyName);
    
        if (permission != null)
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PermissionRequirement(permission.Name));
            return policy.Build();
        }

        return null;
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
        Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

    public Task<AuthorizationPolicy> GetFallbackPolicyAsync() =>
        Task.FromResult<AuthorizationPolicy>(null);
}