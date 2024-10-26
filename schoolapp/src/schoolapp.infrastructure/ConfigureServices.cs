#define UseSqlServer

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schoolapp.application.Common.Interfaces;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Infrastructure.Data;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence.Interceptors;
using schoolapp.Infrastructure.Security.Auth;
using schoolapp.Infrastructure.Security.CurrentUserProvider;
using schoolapp.Infrastructure.Security.RolePermissionService;
using schoolapp.Infrastructure.Security.RoleService;
using schoolapp.Infrastructure.Security.TokenGenerator;
using schoolapp.Infrastructure.Security.TokenValidation;
using schoolapp.Infrastructure.Services;


namespace schoolapp.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddServices()
            .AddAuthentication(configuration)
            .AddAuthorization()
            .AddPersistence(configuration);

        return services;
    }




    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeService, DateTimeService>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        string postgresConnectionString = configuration.GetConnectionString("PostgresConnection");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<SchoolDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

#if !UseSqlServer
                options.UseSqlServer(connectionString);

#else
            options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();

#endif
        });

        services.AddDbContext<AuthDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

#if !UseSqlServer
                options.UseSqlServer(connectionString);

#else
            options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();

#endif
        });
        services.AddScoped<ISchoolDbContext, SchoolDbContext>();

        services.AddScoped<IAuthDbContext, AuthDbContext>();
        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddSingleton<IUserProvider, UserProvider>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        return services;
    }
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.AddScoped<IAuthService, AuthService>();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services
            .AddDefaultIdentity<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>();
        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        services.AddScoped<UserManager<AppUser>>();

        return services;
    }
}