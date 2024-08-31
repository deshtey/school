using schoolapp.Domain.Entities.People;
using System.ComponentModel.DataAnnotations;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoomStudent
    {
        [Key]
        public int ClassRoomId { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public int SchoolId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
    }
}
