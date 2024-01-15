using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class SupportStaff : Person
    {
        public int StaffId { get; set; }
        public int SchoolId { get; set; }
        public virtual required School School { get; set; }
    }
}
