using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Domain.Entities.People
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string? RegNo { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public List<Department> Departments { get; set; }
        public List<ClassRoom> ClassRooms { get; set; }

    }
}
