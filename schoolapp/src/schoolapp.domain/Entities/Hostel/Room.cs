namespace schoolapp.Domain.Entities.Hostel
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public RoomType RoomType { get; set; }
        public RoomStatus Status { get; set; }
        public ICollection<HostelAllocation> HostelAllocations { get; set; } = new List<HostelAllocation>();
    }

    public enum RoomType
    {
        Single,
        Double,
        Triple,
        Dormitory
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        Reserved,
        UnderMaintenance
    }
}