using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schoolapp.application.Common.Interfaces;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Application.Contracts;
using schoolapp.Application.RepositoryInterfaces;
using schoolapp.Application.Services;
using schoolapp.Infrastructure.Data;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence.Interceptors;
using schoolapp.Infrastructure.Repositories;
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
            .AddAuthorizationServices()
            .AddPersistence(configuration);

        return services;
    }




    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IParentService, ParentService>();
        services.AddScoped<IStudentService, StudentService>();

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
            options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();
        });

        services.AddDbContext<AuthDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();
        });
        services.AddScoped<ISchoolDbContext, SchoolDbContext>();
        services.AddScoped<IAuthDbContext, AuthDbContext>();
        return services;
    }

    public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            // Create a scope to access scoped services during configuration
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

            // Get permissions from DB
            var permissions = dbContext.Permissions
                .Select(p => p.Name)
                .ToList();

            // Register each permission as a policy
            foreach (var permission in permissions)
            {
                options.AddPolicy(permission,
                    policy => policy.Requirements.Add(new PermissionRequirement(permission)));
            }
        });

        // Register required services
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
    
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();

        return services;
    }
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IParentRepository, ParentRepository>();
        //services.AddScoped<ITeacherRepository, TeacherRepository>();
        //services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IAcademicRepository, AcademicRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

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