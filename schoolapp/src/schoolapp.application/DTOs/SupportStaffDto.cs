using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class SupportStaffDto
    {
        public int? StaffId { get; set; }
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
