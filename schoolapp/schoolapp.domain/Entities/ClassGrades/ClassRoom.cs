using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public int Year { get; set; }
        public int GradeId { get; set; }
        public string ClassroomName { get; set; }
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public Teacher ClassTeacher { get; set; }
        public ICollection<Student> Students { get; set; }=[];
    }
}
