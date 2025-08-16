using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Events
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public EventParticipationStatus ParticipationStatus { get; set; }
        public string? Remarks { get; set; }
    }

    public enum EventParticipationStatus
    {
        Invited,
        Confirmed,
        Attended,
        Cancelled
    }
}