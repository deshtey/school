using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities
{
    public class School : BaseAuditableEntity
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? HomePage { get; set; } = string.Empty;

    }
}
