namespace schoolapp.Domain.Entities.Notifications
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}