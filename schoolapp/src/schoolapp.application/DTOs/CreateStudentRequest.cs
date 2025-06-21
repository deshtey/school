using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class CreateStudentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OtherNames { get; set; }
        public int SchoolId { get; set; }
        public string RegNumber { get; set; }
        public int EnrollmentYearId { get; set; }
        public int InitialGradeId { get; set; }
        public Gender Gender { get; set; } = Gender.Unknown;
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<CreateStudentParentRequest> Parents { get; set; } = new();
    }

    public class CreateStudentParentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? NationalId { get; set; }
        public ParentType ParentType { get; set; }
        public Gender Gender { get; set; }

        // Optional: If parent already exists
        public int? ExistingParentId { get; set; }
    }
}
