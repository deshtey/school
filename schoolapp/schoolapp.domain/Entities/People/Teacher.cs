using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string RegNo { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

    }
}
