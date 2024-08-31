namespace schoolapp.Domain.Entities.Exams
{
    public class GradingRule
    {
        public int Id { get; set; }
        public int FromMarks { get; set; }
        public int ToMarks { get; set; }
        public string Grade { get; set; }
        public string Points { get; set; }
    }
}
