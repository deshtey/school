using schoolapp.Domain.Enums;

namespace schoolapp.Application.DTOs
{
    public class SchoolDto
    {
        public int? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public SchoolTypes SchoolType { get; set; } = SchoolTypes.Primary;

        public string Location { get; set; }
        public string? LogoUrl { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public DateTimeOffset CreatedAt { get; set; }
        public string? HomePage { get; set; } = string.Empty;
        public bool UseSingleName { get; set; } = false;
        public bool IsGroupOfSchools { get; set; } = false;
        public bool UseStreams { get; set; } = true;


        internal static SchoolDto ToSchoolDto(School school)
        {
            if (school == null) return null;

            return new SchoolDto
            {
                SchoolId = school.Id,
                SchoolName = school.SchoolName,
                Address = school.Address,
                City = school.City,
                Street = school.Street,
                PostalCode = school.PostalCode,
                Status = school.Status,
                CreatedAt = school.Created,
                Country = school.Country,
                Email = school.Email,
                HomePage = school.HomePage,
                Phone = school.Phone
            };
        }
    }
}
