using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Entities.Base
{
    [NotMapped]
    public class SchoolAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
