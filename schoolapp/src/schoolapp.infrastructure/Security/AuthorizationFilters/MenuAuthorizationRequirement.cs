using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using schoolapp.Infrastructure.Data;
using System.Text.Json;

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
    private readonly ILogger<PermissionHandler> _logger;

    public PermissionHandler(ILogger<PermissionHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (!context.User.Identity?.IsAuthenticated ?? true)
        {
            return Task.CompletedTask;
        }

        try
        {
            var permissionsClaim = context.User.FindFirst("permissions");
            if (permissionsClaim != null)
            {
                var permissions = JsonSerializer.Deserialize<List<string>>(permissionsClaim.Value);
                if (permissions.Contains(requirement.Permission))
                {
                    context.Succeed(requirement);
                }
            }      
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking permission {Permission}", requirement.Permission);
        }

        return Task.CompletedTask;
    }
}
//public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
//{
//    private readonly IMemoryCache _cache;
//    private readonly ILogger<PermissionHandler> _logger;
//    private readonly IServiceProvider _serviceProvider;
//    private readonly IHttpContextAccessor _httpContext;
//    //private readonly IUserProvider _userProvider;

//    public PermissionHandler(IServiceProvider serviceProvider, IHttpContextAccessor httpContext
//, IMemoryCache cache
//, ILogger<PermissionHandler> logger
//        //,IUserProvider userProvider
//        )
//    {

//        _serviceProvider = serviceProvider;
//        _httpContext = httpContext;
//        _cache = cache;
//        _logger = logger;
//        //_userProvider = userProvider;
//    }

//    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
//    {
//        try
//        {


//        using var scope = _serviceProvider.CreateScope();
//        var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
//        var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


//        if (!context.User.Identity.IsAuthenticated)
//        {
//            return;
//        }
//        var user = await _userManager.GetUserAsync(context.User);
//        if (user == null)
//        {
//            return;
//        }

//        var userRoles = await _userManager.GetRolesAsync(user);

//        var hasAccess = await dbContext.Roles
//            .Where(r => userRoles.Contains(r.Name))
//            .Join(dbContext.RolePermissions,
//                role => role.Id,
//                rp => rp.RoleId,
//                (role, rp) => rp.Permission.Name)
//            .AnyAsync(permissionName => permissionName == requirement.Permission);

//        if (hasAccess)
//        {
//            context.Succeed(requirement);
//        }
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Error in PermissionHandler");
//            throw;
//        }
//    }
//}

//public class PermissionPolicyProvider : IAuthorizationPolicyProvider
//{
//    private readonly IServiceProvider _serviceProvider;

//    public PermissionPolicyProvider(IServiceProvider serviceProvider)
//    {
//        _serviceProvider = serviceProvider;
//    }

//    public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
//    {
//        using var scope = _serviceProvider.CreateScope();
//        var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

//        var permission = await dbContext.Permissions.FirstOrDefaultAsync(p => p.Name == policyName);
    
//        if (permission != null)
//        {
//            var policy = new AuthorizationPolicyBuilder();
//            policy.AddRequirements(new PermissionRequirement(permission.Name));
//            return policy.Build();
//        }

//        return null;
//    }

//    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
//        Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

//    public Task<AuthorizationPolicy> GetFallbackPolicyAsync() =>
//        Task.FromResult<AuthorizationPolicy>(null);
//}