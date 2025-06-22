using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using schoolapp.Infrastructure.Data;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.TokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly AuthDbContext _dbContext;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, AuthDbContext dbContext)
    {
        _jwtSettings = jwtSettings.Value;
        _dbContext = dbContext;
    }

    public async Task<string> GenerateTokenAsync(AppUser user, IEnumerable<string> userRoles)
    {

       var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Get all permissions for user's roles in one query
        var permissions = _dbContext.UserRoles
            .Where(ur => ur.UserId == user.Id)
            .Join(
                _dbContext.RolePermissions,
                ur => ur.RoleId,
                rp => rp.RoleId,
                (ur, rp) => rp
            )
            .Join(
                _dbContext.Permissions,
                rp => rp.PermissionId,
                p => p.Id,
                (rp, p) => p.Name
            ).ToList();

        var claims = new List<Claim>
        {
            //new(JwtRegisteredClaimNames.Name, appUser. firstName),
            //new(JwtRegisteredClaimNames.FamilyName, lastName),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Iss, "school_app"),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email),
            // Add permissions as claims
            new("permissions", JsonSerializer.Serialize(permissions))
        
        };

        // Add roles
        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
        var token = new JwtSecurityToken(
             _jwtSettings.Issuer,
             _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}