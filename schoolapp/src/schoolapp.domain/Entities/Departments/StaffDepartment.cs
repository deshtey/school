
namespace schoolapp.Domain.Entities.Departments
{
    public class StaffDepartment
    {
        public int StaffDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public int? TeacherId { get; set; }
        public int? StaffId { get; set; }
    }
}
