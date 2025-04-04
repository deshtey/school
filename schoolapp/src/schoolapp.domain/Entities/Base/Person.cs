namespace schoolapp.Domain.Entities.Base;

public abstract class Person : BaseAuditableEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? OtherNames { get; set; }
    public string? NationalId { get; set; }
    public string? Salutation { get; set; }
    public string? Image { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DOB { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }

    private string fullName;

    public string GetFullName()
    {
        if (string.IsNullOrEmpty(fullName))
        {
            if (string.IsNullOrEmpty(OtherNames))
            {
                fullName = $"{FirstName} {LastName}".Trim();
            }
            else
            {
                fullName = $"{FirstName} {OtherNames} {LastName}".Trim();
            }
        }
        return fullName;
    }
}
