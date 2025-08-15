using schoolapp.Domain.Entities.ClassGrades;

namespace schoolapp.Domain.Entities.Financial
{
    public class FeeStructure
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}