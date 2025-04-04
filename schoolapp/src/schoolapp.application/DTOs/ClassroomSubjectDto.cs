namespace schoolapp.Application.DTOs
{
    public class ClassRoomSubjectDto
    {
        public int? Id { get; set; }
        public int ClassRoomId { get; set; }
        public int SchoolSubjectId { get; set; }
        public bool Elective { get; set; } = false;
        public string? SubjectName { get; set; }
    }
}
