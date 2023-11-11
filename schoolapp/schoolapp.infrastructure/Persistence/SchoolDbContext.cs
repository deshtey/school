using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Domain.Entities;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Data;

public class SchoolDbContext : IdentityDbContext<SchoolUser>,ISchoolDbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<School> Schools => Set<School>();

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
    }
}
