namespace schoolapp.Domain.Entities.Academics
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public string SlotName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    }
}