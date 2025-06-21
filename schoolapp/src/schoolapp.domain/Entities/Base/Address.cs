using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Domain.Entities.Base
{
    [NotMapped]
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public string GetFormattedAddress()
        {
            var parts = new List<string>();

            if (!string.IsNullOrWhiteSpace(Street)) parts.Add(Street);
            if (!string.IsNullOrWhiteSpace(City)) parts.Add(City);
            if (!string.IsNullOrWhiteSpace(State)) parts.Add(State);
            if (!string.IsNullOrWhiteSpace(PostalCode)) parts.Add(PostalCode);
            if (!string.IsNullOrWhiteSpace(Country)) parts.Add(Country);

            return string.Join(", ", parts);
        }
    }
}
