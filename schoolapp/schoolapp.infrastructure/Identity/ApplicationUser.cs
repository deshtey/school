using Microsoft.AspNetCore.Identity;

namespace schoolapp.Infrastructure.Identity;

public class SchoolUser : IdentityUser
{
    public string UserName { get; set; }
}
