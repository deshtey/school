namespace schoolapp.Domain.Entities.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public EventStatus Status { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
    }

    public enum EventStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }
}