using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Parent : Person
    {
        public int ParentId { get; set; }
        //public string StudentId { get; set; }
        public virtual School School { get; set; }
    }
}
