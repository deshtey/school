using System.Reflection;
using FluentValidation;
using schoolapp.Application.Contracts;
using schoolapp.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<ISchoolService, SchoolService>();

        return services;
    }
}
