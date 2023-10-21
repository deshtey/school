using System.Reflection;
using schoolapp.Application.Common.Behaviours;
using schoolapp.Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
 

        return services;
    }
}
