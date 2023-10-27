using schoolapp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Common.Interfaces;

public interface ISchoolDbContext
{
    DbSet<School> Schools { get; }

    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<Driver> Drivers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
