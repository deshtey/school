using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoomStudent
    {
        public int ClassRoomId { get; set; }
        public string StudentRegNumber { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
    }
}
