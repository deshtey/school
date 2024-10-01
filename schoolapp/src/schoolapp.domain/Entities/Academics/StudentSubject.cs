using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Academics
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ClassroomSubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool Elective { get; set; }
        public Student Student { get; set; }
        public ClassRoomSubject ClassRoomSubject { get; set; }
    }
}
