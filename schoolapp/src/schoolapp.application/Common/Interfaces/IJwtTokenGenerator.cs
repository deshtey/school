
namespace schoolapp.application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        string id,
        string firstName,
        string lastName,
        string email
        //List<string?> permissions,
        //List<string?> roles
        );
}