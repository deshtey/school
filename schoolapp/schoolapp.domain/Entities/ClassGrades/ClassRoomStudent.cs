using schoolapp.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoomStudent
    {
        [Key]
        public int ClassRoomId { get; set; }
        public string StudentRegNumber { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
    }
}
