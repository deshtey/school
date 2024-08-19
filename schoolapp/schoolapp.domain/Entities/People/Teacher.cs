using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string? RegNo { get; set; }
        public int SchoolId { get; set; }
        public int DepartmentId { get; set; }
        public School School { get; set; }
        public Department Department { get; set; }
        public List<ClassRoom> ClassRoom { get; set; }

    }
}
