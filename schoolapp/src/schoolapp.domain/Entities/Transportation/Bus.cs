namespace schoolapp.Domain.Entities.Transportation
{
    public class Bus
    {
        public int Id { get; set; }
        public string BusNumber { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public int Capacity { get; set; }
        public string RouteName { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public BusStatus Status { get; set; }
        public ICollection<StudentTransport> StudentTransports { get; set; } = new List<StudentTransport>();
    }

    public enum BusStatus
    {
        Active,
        Inactive,
        UnderMaintenance
    }
}