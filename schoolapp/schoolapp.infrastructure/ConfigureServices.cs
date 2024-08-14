
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
            services.AddScoped<IUserProvider, UserProvider>();

            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IDateTimeService,DateTimeService>();
            services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();


            services.AddDbContext<SchoolDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

#if UseSQLServer
              //options.UseSqlite(connectionString);
               options.UseSqlServer(connectionString);

#else
                options.UseNpgsql(connectionString);

#endif
            });

            services.AddScoped<ISchoolDbContext, SchoolDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Tribute, TributeDto>());

            //services.AddScoped<ApplicationDbContextInitialiser>();

            services
                .AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SchoolDbContext>();

            services.AddScoped<UserManager<AppUser>>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<RoleManager<IdentityRole>>();

            //services.AddSingleton<IDateTimeService, DateTimeService>();

            //services.AddAuthorization(options =>
            //    options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error during migration: {ex.Message}");
            throw;
        }
        return services;
    }
}