using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;
using System.Text.Json.Serialization;

namespace schoolapp.Application.DTOs
{
    public class StudentParentDto
    {
        public int? Id { get; set; }
        public int SchoolId { get; set; }
        public StudentDto StudentDto { get; set; } = new();
        public List<ParentDto> ParentsDto { get; set; } = [];
    }
    public class StudentDto
    {
        public int? Id { get; set; }
        public string RegNumber { get; set; }
        public int? ClassroomId { get; set; }
        public string? StudentClass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OtherName { get; set; }
        public string? FullName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class ParentDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? FullName { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
