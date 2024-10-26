using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.TokenGenerator;

public interface IJwtTokenGenerator
{
    string GenerateToken(AppUser user, List<string> roles = null);
}