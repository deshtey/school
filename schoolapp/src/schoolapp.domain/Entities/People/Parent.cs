using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Parent : Person
    {
        public int SchoolId { get; set; }
        public int StudentId { get; set; }
        public List<Student> Students { get; set; } = [];
        public List<StudentParent> StudentParents { get; set; } = [];
        public School School { get; set; }
    }
}
