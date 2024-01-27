namespace schoolapp.Domain.Entities.Syllabus
{
    public class Timetable
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int SubjectId { get; set; }
        public int ActivityId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeOnly Starts { get; set; }
        public TimeOnly Ends { get; set; }
    }
}
