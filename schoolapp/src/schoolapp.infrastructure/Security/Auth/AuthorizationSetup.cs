using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace schoolapp.Infrastructure.Security.Auth
{
    public static class AuthorizationSetup
    {
        public static IServiceCollection AddPermissionBasedAuthorization(
            this IServiceCollection services,
            Action<AuthorizationOptions, IServiceProvider> configurePermissions)
        {
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            services.AddAuthorization(options =>
            {
                using var scope = services.BuildServiceProvider().CreateScope();
                configurePermissions(options, scope.ServiceProvider);
            });

            return services;
        }
    }

  
}
