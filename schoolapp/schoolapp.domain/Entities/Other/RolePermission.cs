namespace schoolapp.Domain.Entities.Other
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
