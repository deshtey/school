using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Application.Common.Interfaces
{
    public interface IAuthDbContext:IDisposable
    {
        DbSet<RolePermission> RolePermissions { get; set; }
        DbSet<Permission> Permissions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        //  transaction support
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
