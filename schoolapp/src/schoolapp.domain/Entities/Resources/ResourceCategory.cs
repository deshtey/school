namespace schoolapp.Domain.Entities.Resources
{
    public class ResourceCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }
}