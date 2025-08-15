using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Notifications
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int? RecipientId { get; set; }
        public Person Recipient { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public NotificationStatus Status { get; set; }
        public string? ReferenceUrl { get; set; }
    }

    public enum NotificationStatus
    {
        Sent,
        Read,
        Archived,
        Deleted
    }
}