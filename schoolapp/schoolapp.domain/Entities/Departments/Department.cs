using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Departments
{
    public class Department
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentHead { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SupportStaff> Staff { get; set; }
    }
}
