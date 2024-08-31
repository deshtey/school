namespace schoolapp.Domain.Entities.Exams
{
    public class StudentExam
    {
        public int StudentExamId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double FinalScore { get; set; }
        public int ClassPosition { get; set; }
        public string FinalGrade { get; set; }
        public string TeacherComments { get; set; }
        public string ParentComments { get; set; }
        public string StudentComments { get; set; }
        
    }
}
