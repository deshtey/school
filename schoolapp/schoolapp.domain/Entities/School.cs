namespace schoolapp.Domain.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; } = string.Empty;

    }
}
