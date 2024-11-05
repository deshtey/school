using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.TokenGenerator;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(AppUser user, IEnumerable<string> userRoles);
}