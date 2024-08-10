namespace schoolapp.Infrastructure.Identity
{
    public class UserDto
    {
        public AppUser User { get; set; }
        public string AccessToken { get; set; }
    }
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
