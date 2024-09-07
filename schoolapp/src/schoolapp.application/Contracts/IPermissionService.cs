using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Other;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Contracts
{
    public interface IPermissionService
    {
        Task<bool> DeletePermission(int id, CancellationToken cancellationToken);
        Task<Permission?> GetPermission(int id);
        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<bool> PostPermission(Permission permission, CancellationToken cancellationToken);
        Task<Permission?> PutPermission(int id, Permission permission, CancellationToken cancellationToken);

    }
}
