namespace schoolapp.Domain.Entities.Exams
{
    public class StudentMarks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StudentExamId { get; set; }
        public int SubjectId { get; set; }
        public double Score { get; set; }
    }
}
