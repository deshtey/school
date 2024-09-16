using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;
using schoolapp.Domain.Entities.People;
using schoolapp.Infrastructure.Persistence.Configurations;
namespace schoolapp.Infrastructure.Data;

public class SchoolDbContext : DbContext, ISchoolDbContext
{
    private IDbContextTransaction _currentTransaction;
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
    public DbSet<School> Schools { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentParent> StudentParents { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<SupportStaff> SupportStaffs { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Department> Departments { get; set; }
    //public DbSet<Permission> Permissions { get; set; }
    //public DbSet<RolePermission> RolePermissions { get; set; }

    //public DbSet<ExamType> ExamTypes { get; set; }
    //public DbSet<ClassRoomStudent> ClassRoomStudents { get; set; }
    public DbSet<Grade> Grades { get; set; }
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
