using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string RegNo { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }

    }
}
