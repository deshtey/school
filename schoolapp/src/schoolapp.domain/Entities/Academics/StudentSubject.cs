using schoolapp.Domain.Entities.Exams;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Academics
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public bool Elective { get; set; }
        public SchoolSubject Subject { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public double? FinalGrade { get; set; }
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();

        // Calculate final grade based on assessments
        public void CalculateFinalGrade()
        {
            if (!Assessments.Any())
            {
                FinalGrade = null;
                return;
            }

            double totalWeight = Assessments.Sum(a => a.Weight);
            double weightedSum = Assessments.Sum(a => a.Grade * a.Weight);

            FinalGrade = weightedSum / totalWeight;
        }
    }
}
