using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class StudentParentDto
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public StudentDto StudentDto { get; set; } = new();
        public List<ParentDto> ParentsDto { get; set; } = [];
    }
    public class StudentDto
    {
        public string RegNumber { get; set; }
        public int? ClassroomId { get; set; }
        public string? StudentClass { get; set; }
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class ParentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
