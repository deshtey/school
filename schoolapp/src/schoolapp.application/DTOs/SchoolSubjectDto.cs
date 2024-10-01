namespace schoolapp.Application.DTOs
{
    public class SchoolSubjectDto
    {
        public int? Id { get; set; }
        public int SchoolId { get; set; }
        public string SubjectName { get; set; }
        public string? Desc { get; set; }
    }
}
