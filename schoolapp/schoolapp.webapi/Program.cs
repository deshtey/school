using lovedmemory.web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using schoolapp.Infrastructure;
using schoolapp.Infrastructure.Security.AuthorizationFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string conString = "Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;MultipleActiveResultSets=true";
//builder.Services.AddDbContext<SchoolDbContext>(options =>
//        options.UseSqlServer(conString));
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<AuthorizationFilter>();
});

// Swagger/OpenAPI setup
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric=false;
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

