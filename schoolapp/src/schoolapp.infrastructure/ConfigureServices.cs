#define UseSqlServer

using Microsoft.AspNetCore.Authentication.JwtBearer;
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

namespace schoolapp.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            string postgresConnectionString = configuration.GetConnectionString("PostgresConnection");
            //var connectionString = "Server=DESKTOP-9ON65SB;Database=school_db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            //var postgresConnectionString = "Host=localhost;Database=schooldb;Username=postgres;Password=Working24;";
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IUserProvider, UserProvider>();
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

            services.AddScoped<ISchoolDbContext, SchoolDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
   
            services
                .AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SchoolDbContext>();

            services.AddScoped<UserManager<AppUser>>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddSingleton<IDateTimeService, DateTimeService>();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<SchoolDbContext>>();

            logger.LogInformation("Starting to add infrastructure services");

 

            logger.LogInformation("configs: {}", configuration);
            logger.LogInformation("connection string: {}", connectionString);


        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error during migration: {ex.Message}");
            throw;
        }
        return services;
    }
}