using System.Reflection;
using schoolapp.Domain.Entities;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace schoolapp.Infrastructure.Persistence;

public class SchoolDbContext : ApiAuthorizationDbContext<SchoolUser>
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public SchoolDbContext(
        DbContextOptions<SchoolDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<School> Schools => Set<School>();

    //public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    //public DbSet<Category> Categories => Set<Category>();
    //public DbSet<Cart> Carts => Set<Cart>();
    //public DbSet<CartItem> CartItems => Set<CartItem>();
    //public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
    { 
        return await base.SaveChangesAsync(cancellationToken);
    }
}
