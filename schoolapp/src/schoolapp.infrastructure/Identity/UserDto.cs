namespace schoolapp.Infrastructure.Identity
{
    public class UserDto
    {
        public AppUserDto User { get; set; }
        public string AccessToken { get; set; }
    }
    public class AppUserDto 
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string FullName { get; set; }
        public string? CountryCode { get; set; } = "ke";


    }
}
