namespace schoolapp.Domain.Entities.Base;

public abstract class Person : BaseAuditableEntity
{
    private string? _fullName;

    protected Person(string firstName, string lastName, int schoolId, Gender gender = Gender.Unknown)
    {
        // Input validation
        FirstName = !string.IsNullOrWhiteSpace(firstName)
            ? firstName.Trim()
            : throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));

        LastName = !string.IsNullOrWhiteSpace(lastName)
            ? lastName.Trim()
            : throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

        SchoolId = schoolId > 0
            ? schoolId
            : throw new ArgumentException("School ID must be greater than 0.", nameof(schoolId));

        Gender = gender;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? OtherNames { get; set; }
    public string? NationalId { get; set; }
    public string? Salutation { get; set; }
    public string? Image { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    // Group address properties into a value object or separate class
    public Address? Address { get; set; }

    public int SchoolId { get; private set; }
    public virtual School School { get; set; } = null!;

    // Computed property with proper caching and invalidation
    public string FullName
    {
        get
        {
            if (_fullName == null)
            {
                var names = new List<string> { FirstName };

                if (!string.IsNullOrWhiteSpace(OtherNames))
                    names.Add(OtherNames.Trim());

                names.Add(LastName);

                _fullName = string.Join(" ", names);
            }
            return _fullName;
        }
    }

    // Method to update name and invalidate cache
    public void UpdateName(string firstName, string lastName, string? otherNames = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        OtherNames = string.IsNullOrWhiteSpace(otherNames) ? null : otherNames.Trim();

        // Invalidate cached full name
        _fullName = null;
    }

    // Method to transfer to different school
    public void TransferToSchool(int newSchoolId)
    {
        if (newSchoolId <= 0)
            throw new ArgumentException("School ID must be greater than 0.", nameof(newSchoolId));

        SchoolId = newSchoolId;
        School = null!; // Will be loaded by EF Core navigation
    }

    // Helper method for age calculation
    public int? GetAge()
    {
        if (!DateOfBirth.HasValue)
            return null;

        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Value.Year;

        if (DateOfBirth.Value.Date > today.AddYears(-age))
            age--;

        return age;
    }

    // Override ToString for better debugging
    public override string ToString() => $"{FullName} (ID: {Id})";
}

// Address value object to better organize address-related properties
