using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Resources
{
    public class ResourceAllocation
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ResourceAllocationStatus Status { get; set; }
        public string? Remarks { get; set; }
    }

    public enum ResourceAllocationStatus
    {
        Allocated,
        Returned,
        Overdue
    }
}