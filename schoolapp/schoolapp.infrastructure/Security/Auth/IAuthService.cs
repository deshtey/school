using schoolapp.application.DTOs;
using schoolapp.Infrastructure.Identity;
namespace schoolapp.Infrastructure.Security.Auth;

public interface IAuthService
{
    Task<UserDto> Register(RegisterDto request);
    Task<UserDto> Login(LoginDto request);
}
