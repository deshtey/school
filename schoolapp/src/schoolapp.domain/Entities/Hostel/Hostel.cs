namespace schoolapp.Domain.Entities.Hostel
{
    public class Hostel
    {
        public int Id { get; set; }
        public string HostelName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public HostelType HostelType { get; set; }
        public HostelStatus Status { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

    public enum HostelType
    {
        Boys,
        Girls,
        Mixed
    }

    public enum HostelStatus
    {
        Active,
        Inactive,
        UnderMaintenance
    }
}