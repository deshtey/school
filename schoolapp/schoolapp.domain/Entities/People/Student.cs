using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Student : Person
    {
        public string RegNumber { get; set; }
        public bool Status { get; set; }
        public DateTime JoinDate { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }

    }
}
