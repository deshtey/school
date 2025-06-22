using schoolapp.Application.DTOs;

namespace schoolapp.Application.Common.Mappings
{
    public static class DtoConverters
    {
        public static SchoolDto ToSchoolDto(School school)
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
