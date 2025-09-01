using System.Collections.Generic;
using System.Text.RegularExpressions;
using schoolapp.Domain.Common;

namespace schoolapp.Domain.ValueObjects
{
    public class ContactInfo : ValueObject
    {
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string? SecondaryPhone { get; private set; }

        private ContactInfo() { } // EF Core constructor

        public ContactInfo(string email, string phone, string? secondaryPhone = null)
        {
            Email = ValidateEmail(email);
            Phone = ValidatePhone(phone);
            SecondaryPhone = secondaryPhone != null ? ValidatePhone(secondaryPhone) : null;
        }

        private string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email.Trim()))
                throw new ArgumentException("Invalid email format", nameof(email));

            return email.Trim().ToLower();
        }

        private string ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Phone cannot be null or empty", nameof(phone));

            var phoneRegex = new Regex(@"^[\+]?[1-9][\d]{0,15}$");
            if (!phoneRegex.IsMatch(phone.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")))
                throw new ArgumentException("Invalid phone format", nameof(phone));

            return phone.Trim();
        }

        public ContactInfo WithEmail(string email)
        {
            return new ContactInfo(email, Phone, SecondaryPhone);
        }

        public ContactInfo WithPhone(string phone)
        {
            return new ContactInfo(Email, phone, SecondaryPhone);
        }

        public ContactInfo WithSecondaryPhone(string? secondaryPhone)
        {
            return new ContactInfo(Email, Phone, secondaryPhone);
        }

        public bool IsValidEmail()
        {
            try
            {
                ValidateEmail(Email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhone()
        {
            try
            {
                ValidatePhone(Phone);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email.ToLower();
            yield return Phone;
            yield return SecondaryPhone ?? string.Empty;
        }

        public override string ToString()
        {
            return $"Email: {Email}, Phone: {Phone}" +
                   (SecondaryPhone != null ? $", Secondary: {SecondaryPhone}" : "");
        }
    }
}