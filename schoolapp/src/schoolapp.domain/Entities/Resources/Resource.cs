namespace schoolapp.Domain.Entities.Resources
{
    public class Resource
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public int ResourceCategoryId { get; set; }
        public ResourceCategory ResourceCategory { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public ResourceStatus Status { get; set; }
        public string Location { get; set; }
        public ICollection<ResourceAllocation> ResourceAllocations { get; set; } = new List<ResourceAllocation>();
        public string ResourceType { get; set; }
    }

    public enum ResourceStatus
    {
        Available,
        InUse,
        UnderMaintenance,
        Damaged,
        Retired
    }
}