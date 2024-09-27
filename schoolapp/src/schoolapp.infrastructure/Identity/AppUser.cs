using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public string? CountryCode { get; set; } = "ke";
    public string? OtherName { get; set; }
    [NotMapped]
    public string FullName
    {
        get
        {
            if (string.IsNullOrEmpty(LastName))
                return FirstName;
            else
                return $"{FirstName} {LastName}";
        }
    }

}
