namespace schoolapp.Application.DTOs
{
    public class StudentSubjectDto
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ClassroomSubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool Elective { get; set; }
    }
}
