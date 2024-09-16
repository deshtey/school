using schoolapp.Domain.Entities.Other;

namespace schoolapp.Application.DTOs
{
    public class RolePermissionDto
    {
        public int? Id { get; set; }
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
