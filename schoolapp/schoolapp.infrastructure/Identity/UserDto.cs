using schoolapp.Domain.Entities.Identity;

namespace schoolapp.Infrastructure.Identity
{
    public class UserDto
    {
        public AppUser User { get; set; }
        public string AccessToken { get; set; }
    }
}
