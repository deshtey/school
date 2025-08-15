namespace schoolapp.Domain.Entities.Health
{
    public class MedicalCondition
    {
        public int Id { get; set; }
        public string ConditionName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public bool IsChronic { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}