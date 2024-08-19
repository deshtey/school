using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class SupportStaff : Person
    {
        public int StaffId { get; set; }
        public int SchoolId { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public School School { get; set; }
    }
}
