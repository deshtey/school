using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Transportation
{
    public class StudentTransport
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int BusStopId { get; set; }
        public BusStop BusStop { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StudentTransportStatus Status { get; set; }
    }

    public enum StudentTransportStatus
    {
        Active,
        Inactive,
        Suspended
    }
}