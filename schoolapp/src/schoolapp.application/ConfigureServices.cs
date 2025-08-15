using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using schoolapp.Application.Contracts;
using schoolapp.Application.Services;
using studentapp.Application.Services;

namespace schoolapp.Application;

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
        services.AddScoped<ISchoolSubjectService, SchoolSubjectService>();
        services.AddScoped<IStudentSubjectService, StudentSubjectService>();
        services.AddScoped<IClassRoomSubjectService, ClassRoomSubjectService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IAcademicYearService, AcademicYearService>();

        return services;
    }
}
