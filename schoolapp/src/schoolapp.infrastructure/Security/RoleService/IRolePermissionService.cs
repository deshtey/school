
using Microsoft.AspNetCore.Identity;
using schoolapp.Application.DTOs;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Security.RolePermissionService
{
    public interface IRolePermissionService
    {
        Task<bool> AssignRolePermissionToUserAsync(string userId, string rolepermissionName);
        Task<RolePermission> CreateRolePermissionAsync(RolePermissionDto rolePermission);
        Task<bool> DeleteRolePermissionAsync(int id);
        Task<bool> EditRolePermissionAsync(int id, RolePermissionDto rolePermission);
        Task<List<RolePermissionDto>> GetRolePermissions();
    }
}
