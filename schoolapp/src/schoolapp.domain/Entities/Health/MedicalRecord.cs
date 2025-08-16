using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Health
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string BloodGroup { get; set; }
        public string Allergies { get; set; }
        public string Remarks { get; set; }
        public string Prescription { get; set; }
        public string Doctor { get; set; }
        public string MedicalConditions { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();
    }
}