using schoolapp.Application.Common.Interfaces;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence;
using schoolapp.Infrastructure.Persistence.Interceptors;
using schoolapp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{
        //    services.AddDbContext<SchoolDbContext>(options =>
        //        options.UseInMemoryDatabase("schoolappDb"));
        //}
        //else
        //{
        //    services.AddDbContext<SchoolDbContext>(options =>
        //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        //}

        services.AddScoped(provider => provider.GetRequiredService<SchoolDbContext>());

        //services.AddScoped<SchoolDbContextInitialiser>();

        services
            .AddDefaultIdentity<SchoolUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SchoolDbContext>();

        //services.AddIdentityServer()
        //    .AddApiAuthorization<SchoolUser, SchoolDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
       // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
