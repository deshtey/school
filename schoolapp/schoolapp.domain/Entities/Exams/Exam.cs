namespace schoolapp.Domain.Entities.Exams
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamTypeId { get; set; }
        public virtual 
            
            
            
            
            
            
            
            
            
            
            
            
            ExamType ExamType { get; set; }
    }
}
