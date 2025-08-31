namespace schoolapp.Application.DTOs
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}