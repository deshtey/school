#define UseSqlServer

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using schoolapp.application.Common.Interfaces;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Infrastructure.Data;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence.Interceptors;
using schoolapp.Infrastructure.Security.Auth;
using schoolapp.Infrastructure.Security.CurrentUserProvider;
using schoolapp.Infrastructure.Security.RoleService;
using schoolapp.Infrastructure.Security.TokenGenerator;
using schoolapp.Infrastructure.Security.TokenValidation;
using schoolapp.Infrastructure.Services;
using System.Net.Mail;
using System.Net;
using System;

namespace schoolapp.Infrastructure;

public static class DependencyInjection
{

//    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
//    {
//        try
//        {
// //var connectionString = "Server=DESKTOP-9ON65SB;Database=school_db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
//            //var postgresConnectionString = "Host=localhost;Database=schooldb;Username=postgres;Password=Working24;";
//            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


//            services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();


//            services.AddDbContext<SchoolDbContext>((sp, options) =>
//            {
//                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

//#if !UseSqlServer
//                options.UseSqlServer(connectionString);

//#else
//                options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();

//#endif
//            });

//            services.AddScoped<ISchoolDbContext, SchoolDbContext>();
//            services.AddScoped<IAuthService, AuthService>();
//            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
//            services
//                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
//                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer();
   
//            services
//                .AddDefaultIdentity<AppUser>()
//                .AddRoles<IdentityRole>()
//                .AddEntityFrameworkStores<SchoolDbContext>();

//            services.AddScoped<UserManager<AppUser>>();
//            services.AddTransient<IIdentityService, IdentityService>();

//            services.AddScoped<IRoleService, RoleService>();

//            //services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
//            //services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

//            var serviceProvider = services.BuildServiceProvider();
//            var logger = serviceProvider.GetRequiredService<ILogger<SchoolDbContext>>();

//            logger.LogInformation("Starting to add infrastructure services");

 

//            logger.LogInformation("configs: {}", configuration);
//            logger.LogInformation("connection string: {}", connectionString);


//        }
//        catch (Exception ex)
//        {

//            Console.WriteLine($"Error during migration: {ex.Message}");
//            throw;
//        }
//        return services;
//    }
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

        services.AddDbContext<SchoolDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

#if !UseSqlServer
                options.UseSqlServer(connectionString);

#else
            options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention();

#endif
        });

        services.AddScoped<ISchoolDbContext, SchoolDbContext>();

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddSingleton<IUserProvider, UserProvider>();

        return services;
    }
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services
            .AddDefaultIdentity<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SchoolDbContext>();
        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        services.AddScoped<UserManager<AppUser>>();

        return services;
    }
}