using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.People
{
    public class Student : Person
    {
        public string RegNumber { get; set; }
        public int ClassroomId { get; set; }
        public StudentAddress StudentAddress { get; set; }
        public ClassRoom StudentClass { get; set; }
        public List<Parent> Parents { get; set; } = [];
        public List<StudentParent> StudentParents { get; set; } = [];
    }
}
