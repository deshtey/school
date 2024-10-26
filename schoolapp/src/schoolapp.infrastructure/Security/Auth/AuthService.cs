using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using schoolapp.application.DTOs;
using schoolapp.Infrastructure.Identity;
using schoolapp.Infrastructure.Security.TokenGenerator;

namespace schoolapp.Infrastructure.Security.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager, IJwtTokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<UserDto> Register(RegisterDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        //var userByUsername = await _userManager.FindByNameAsync(request.Username);
        if (userByEmail is not null)
        {
            throw new ArgumentException($"User with email {request.Email} already exists.");
        }

        AppUser user = new()
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.Firstname,
            LastName = request.Lastname,
            OtherName = request.Othername,

            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {string.Concat(request.Firstname, " ", request.Lastname)} errors: {GetErrorsText(result.Errors)}");
        }

        return await Login(new LoginDto { Email = request.Email, Password = request.Password });
    }

    public async Task<UserDto> Login(LoginDto request)
    {
        var user = await _userManager.FindByNameAsync(request.Email);

        user ??= await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException($"Unable to authenticate user {request.Email}");
        }
        var userRoles = await _userManager.GetRolesAsync(user);

        var token = _tokenGenerator.GenerateToken(user, userRoles);

        return new UserDto
        {
            AccessToken = token,
            User = new AppUserDto { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, OtherName = user.OtherName, FullName=user.FullName, PhoneNumber = user.PhoneNumber, Id = user.Id, Avatar = user.Avatar, CountryCode = user.CountryCode }
        };
    }

    public string GetTokenFromRequest(HttpRequest request)
    {
        string token = null;

        // Get the Authorization header from the request
        var authHeader = request.Headers["Authorization"];

        if (authHeader.Count > 0)
        {
            var authValue = authHeader.ToString().Split(' ');
            if (authValue.Length == 2 && authValue[0].Equals("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                token = authValue[1];
            }
        }

        return token;
    }

    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}
