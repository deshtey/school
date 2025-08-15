namespace schoolapp.Domain.Entities.Exams
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamTypeId { get; set; }
        public virtual ExamType ExamType { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        
        // Additional exam information
        public string? Description { get; set; }
        public ExamStatus Status { get; set; } = ExamStatus.Scheduled;
        public double? Weightage { get; set; }
        public double? PassingMarks { get; set; }
        public double? MaximumMarks { get; set; }
    }
    
    public enum ExamStatus
    {
        Draft,
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }
}
