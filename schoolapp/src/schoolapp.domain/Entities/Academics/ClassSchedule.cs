using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Academics
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int SubjectId { get; set; }
        public SchoolSubject Subject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ClassScheduleStatus Status { get; set; }
    }

    public enum ClassScheduleStatus
    {
        Active,
        Inactive,
        Cancelled
    }
}