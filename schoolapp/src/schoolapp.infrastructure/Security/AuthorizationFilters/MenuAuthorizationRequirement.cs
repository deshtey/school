using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
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
