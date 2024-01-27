using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public DateTime Year { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual Teacher ClassTeacher { get; set; }
        public ICollection<Student> Students { get; set; }=new List<Student>();
    }
}
