namespace schoolapp.Domain.Entities.Other
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public IRole Role { get; set; }
    }
}
