namespace schoolapp.Domain.Entities.Syllabus
{
    public class Subject
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string SubjectName { get; set; }
        public bool Elective { get; set; }
    }
}
