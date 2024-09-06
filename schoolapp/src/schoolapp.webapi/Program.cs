using lovedmemory.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using schoolapp.Infrastructure;
using schoolapp.Infrastructure.Security.AuthorizationFilters;
using schoolapp.Infrastructure.Security.CurrentUserProvider;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
Log.Logger = new LoggerConfiguration()
    //.Enrich.With
    .Enrich.FromLogContext() //logging from DiagnosticContext
    .Enrich.WithProperty("ApplicationName", "SchoolApp_web_api")
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    //.WriteTo.Seq("http://localhost:5341")
    .WriteTo.File($"{builder.Environment.ContentRootPath}/Logs/webapi_.txt",
    LogEventLevel.Information,
    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}",
    rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


// Swagger/OpenAPI setup
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});
builder.Services.AddSwaggerGen(opt =>
{
    //opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
    opt.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Scheme = "bearer"
    });
    opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
});
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseCors(options => options
       .AllowAnyHeader()
       .AllowAnyMethod()
       .SetIsOriginAllowed(hostName => true)
       .AllowCredentials()
       .SetPreflightMaxAge(TimeSpan.FromSeconds(86400))
   );
app.UseSwagger();
app.UseSwaggerUI();

// Middleware Configuration
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
