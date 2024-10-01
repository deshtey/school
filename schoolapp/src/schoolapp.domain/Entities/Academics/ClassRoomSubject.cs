using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.Academics
{
    public class ClassRoomSubject
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int SchoolSubjectId { get; set; }
        public bool Elective { get; set; } = false;
        public string SubjectName { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
