using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using schoolapp.Application.Common.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace schoolapp.Infrastructure.Security.CurrentUserProvider
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserProvider> _logger;
        public UserProvider(IHttpContextAccessor httpContextAccessor, ILogger<UserProvider> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public Result<CurrentUser> GetCurrentUser()
        {
            try
            {
                var user = _httpContextAccessor.HttpContext.User;

                if (_httpContextAccessor.HttpContext == null)
                {
                    throw new Exception();
                }
                if (user?.Identity == null || !user.Identity.IsAuthenticated)
                {
                    _logger.LogError("User is not authenticated {user}", user);
                    return Result<CurrentUser>.Failure(["User is not authenticated"]);
                }
                if (_httpContextAccessor.HttpContext.User?.IsAuthenticated() == false)
                {
                    throw new Exception();
                }

                _ = _httpContextAccessor.HttpContext!.User.Claims;
                string id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var permissions = GetClaimValues("permissions");
                var roles = GetClaimValues(ClaimTypes.Role);
                var firstName = "";//GetSingleClaimValue(JwtRegisteredClaimNames.Name);

                // email = GetSingleClaimValue(ClaimTypes.Email);

                var result = new CurrentUser(id, firstName, "", email, permissions, roles);
                return Result<CurrentUser>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("User is not authenticated {user}", ex);
                return Result<CurrentUser>.Failure(["User is not authenticated"]);
            }
        }

        private List<string> GetClaimValues(string claimType) =>
            _httpContextAccessor.HttpContext!.User.Claims
                .Where(claim => claim.Type == claimType)
                .Select(claim => claim.Value)
                .ToList();

        private string GetSingleClaimValue(string claimType) =>
            _httpContextAccessor.HttpContext!.User.Claims
                .Single(claim => claim.Type == claimType)
                .Value;
    }
}
