using System.Collections.Generic;
using schoolapp.Domain.Common;

namespace schoolapp.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        private Address() { } // EF Core constructor

        public Address(string street, string city, string state, string postalCode, string country)
        {
            Street = street?.Trim() ?? throw new ArgumentNullException(nameof(street));
            City = city?.Trim() ?? throw new ArgumentNullException(nameof(city));
            State = state?.Trim() ?? throw new ArgumentNullException(nameof(state));
            PostalCode = postalCode?.Trim() ?? throw new ArgumentNullException(nameof(postalCode));
            Country = country?.Trim() ?? throw new ArgumentNullException(nameof(country));
        }

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
        }

        public Address WithStreet(string street)
        {
            return new Address(street, City, State, PostalCode, Country);
        }

        public Address WithCity(string city)
        {
            return new Address(Street, city, State, PostalCode, Country);
        }

        public Address WithState(string state)
        {
            return new Address(Street, City, state, PostalCode, Country);
        }

        public Address WithPostalCode(string postalCode)
        {
            return new Address(Street, City, State, postalCode, Country);
        }

        public Address WithCountry(string country)
        {
            return new Address(Street, City, State, PostalCode, country);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street.ToLower();
            yield return City.ToLower();
            yield return State.ToLower();
            yield return PostalCode.ToLower();
            yield return Country.ToLower();
        }

        public override string ToString()
        {
            return GetFullAddress();
        }
    }
}