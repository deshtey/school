using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Hostel
{
    public class HostelAllocation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public HostelAllocationStatus Status { get; set; }
        public string? Remarks { get; set; }
    }

    public enum HostelAllocationStatus
    {
        Allocated,
        Released,
        Cancelled
    }
}