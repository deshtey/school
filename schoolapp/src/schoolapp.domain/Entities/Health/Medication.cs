namespace schoolapp.Domain.Entities.Health
{
    public class Medication
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string DoctorName { get; set; }
        public string PrescriptionNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public MedicationStatus Status { get; set; }
    }

    public enum MedicationStatus
    {
        Active,
        Inactive,
        Completed
    }
}