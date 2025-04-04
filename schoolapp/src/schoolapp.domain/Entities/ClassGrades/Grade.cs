using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public ICollection<ClassRoom> ClassRooms { get; set; } = [];
        public double MinimumOverallGradeForPromotion { get; set; } = 60.0;
        public double MinimumGradePerCompulsorySubject { get; set; } = 50.0;
    }
}
