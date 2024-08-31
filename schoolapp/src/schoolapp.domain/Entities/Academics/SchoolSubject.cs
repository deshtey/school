namespace schoolapp.Domain.Entities.Academics
{
    public class ClassRoomSubject
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int SubjectId { get; set; }
        public bool Elective { get; set; }
    }
}
