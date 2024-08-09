using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Parent : Person
    {
        public int ParentId { get; set; }
        public int SchoolId { get; set; }
        public List<StudentParent> StudentParents { get; set; } = new List<StudentParent>();
        public virtual School School { get; set; }
    }
}
