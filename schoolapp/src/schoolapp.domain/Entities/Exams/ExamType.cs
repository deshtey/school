namespace schoolapp.Domain.Entities.Exams
{
    public class ExamType
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
