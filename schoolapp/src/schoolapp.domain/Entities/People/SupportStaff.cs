using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Domain.Entities.People
{
    public class SupportStaff : Person
    {
        public SupportStaff(string firstName, string LastName, int schoolId, Gender gender) : base(firstName, LastName, schoolId, gender)
        {
            // Additional initialization if needed
        }
        public SupportStaff() { }

        public string? StaffNumber { get; set; }
        public int SchoolId { get; set; }
        public string? Designation { get; set; }
        public int? DepartmentId { get; set; }
        public School School { get; set; }
        public List<Department>? Departments { get; set; }
        public string RegNo { get; set; }
    }
}
