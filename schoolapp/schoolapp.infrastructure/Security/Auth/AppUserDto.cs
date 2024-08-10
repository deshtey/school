using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.Auth
{
    internal class AppUserDto : AppUser
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
    }
}