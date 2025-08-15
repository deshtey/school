using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;

namespace schoolapp.Domain.Entities.Attendance
{
    public class StudentAttendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateOnly Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string? Remarks { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        Excused
    }
}