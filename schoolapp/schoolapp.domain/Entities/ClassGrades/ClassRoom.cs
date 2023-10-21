using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public DateTime Year { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        public IEnumerable<Student> Students { get; set; }=new List<Student>();
    }
}
