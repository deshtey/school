namespace schoolapp.Application.DTOs
{
    public class SchoolDto
    {
        public int? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string? HomePage { get; set; } = string.Empty;
    }
}
