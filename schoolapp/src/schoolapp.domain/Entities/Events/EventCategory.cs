namespace schoolapp.Domain.Entities.Events
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}