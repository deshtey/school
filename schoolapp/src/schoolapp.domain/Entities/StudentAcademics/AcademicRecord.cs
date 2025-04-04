using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;
namespace schoolapp.Domain.Entities.StudentAcademics
{
    public class AcademicRecord
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Grade Grade { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public double OverallGrade { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
