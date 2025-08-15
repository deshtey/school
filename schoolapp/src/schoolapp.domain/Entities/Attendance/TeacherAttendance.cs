using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;

namespace schoolapp.Domain.Entities.Attendance
{
    public class TeacherAttendance
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DateOnly Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string? Remarks { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}