using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Entities.Base
{
    public class StudentAddress
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? PrimaryPhone { get; set; }
    }
}
