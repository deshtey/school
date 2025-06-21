using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class SupportStaffDto
    {
        public int? Id { get; set; }
        public string? StaffNumber { get; set; }
        public int SchoolId { get; set; }
        public DateTime? DOB { get; set; }
        public string? Image { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? FullName { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Salutation { get; internal set; }
        public List<DepartmentDto>? Departments { get; set; }
        public string RegNo { get; internal set; }
    }
}
