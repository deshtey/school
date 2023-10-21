using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string RegNo { get; set; }

    }
}
