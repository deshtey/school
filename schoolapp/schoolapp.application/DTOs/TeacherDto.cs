using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.Departments;
using schoolapp.Domain.Entities;
using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class TeacherDto
    {
        public int? TeacherId { get; set; }
        public string? RegNo { get; set; }
        public int SchoolId { get; set; }
        public DateTime? DOB { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<DepartmentDto> Departments { get; set; }
        public List<ClassRoomDto> ClassRooms { get; set; }
    }
}
