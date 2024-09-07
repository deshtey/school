using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities.Other;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Persistence.Configurations;
namespace schoolapp.Infrastructure.Data;

public class AuthDbContext : IdentityDbContext<AppUser>, IAuthDbContext
{
    private IDbContextTransaction _currentTransaction;
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
        {
            return;
        }
        _currentTransaction = await Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);

            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync(cancellationToken);
            }
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("school");

        modelBuilder.ApplyConfiguration(new SchoolEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        // modelBuilder.ApplyConfiguration(new StudentParentConfiguration());


        //convert table names to lowercase
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            //table name
            entity.SetTableName(entity.GetTableName().ToLower());

            //field name
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());
            }

            //Keys
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToLower());
            }

            // indexes
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToLower());
            }

            //fks
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToLower());
            }
        }
    }
}
