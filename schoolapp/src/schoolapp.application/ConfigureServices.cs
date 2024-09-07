using System.Reflection;
using FluentValidation;
using schoolapp.Application.Contracts;
using schoolapp.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IGradeClassRoomService, GradeClassRoomService>();
        services.AddScoped<ISupportStaffService, SupportStaffService>();
        services.AddScoped<IPermissionService, PermissionService>();

        return services;
    }
}
