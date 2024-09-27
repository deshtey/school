using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.DTOs
{
    public class ClassRoomDto
    {
        public int SchoolId { get; set; }  
        public int? ClassRoomId { get; set; }
        public int Year { get; set; }
        public int GradeId { get; set; }
        public string ClassroomName { get; set; }
        public int? TeacherId { get; set; }
        public string? ClassTeacherName { get; set; }
        public ICollection<StudentDto>? Students { get; set; } = [];
    }
}
