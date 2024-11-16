using Microsoft.AspNetCore.Identity;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Identity
{
    public class AppRole : IdentityRole 
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}
