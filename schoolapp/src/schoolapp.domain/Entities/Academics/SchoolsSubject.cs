namespace schoolapp.Domain.Entities.Academics
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string SubjectName { get; set; }
        public bool Elective { get; set; }
        public string? Desc { get; set; }
        public School School { get; set; }
    }
}
