using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Student : Person
    {
        public string RegNumber { get; set; }
        public bool Status { get; set; }
        public DateTime JoinDate { get; set; }


    }
}
