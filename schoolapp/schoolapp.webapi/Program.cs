using Microsoft.OpenApi.Models;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Infrastructure;
using schoolapp.webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string conString = "Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;MultipleActiveResultSets=true";
//builder.Services.AddDbContext<SchoolDbContext>(options =>
//        options.UseSqlServer(conString));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Swagger/OpenAPI setup
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
   // opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
});
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

// Middleware Configuration
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

