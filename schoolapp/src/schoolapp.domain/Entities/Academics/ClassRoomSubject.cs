using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.Academics
{
    public class ClassRoomSubject
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int SchoolSubjectId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
        public bool Elective { get; set; }
        public ClassRoomSubject() { }
        public ClassRoomSubject(int classRoomId, int schoolSubjectId,  bool elective)
        {
            ClassRoomId = classRoomId;
            SchoolSubjectId = schoolSubjectId;
            Elective = elective;
        }
    }
}
