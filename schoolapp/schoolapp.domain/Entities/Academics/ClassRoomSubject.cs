namespace schoolapp.Domain.Entities.Academics
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int SubjectId { get; set; }
        public bool Elective { get; set; }
    }
}
