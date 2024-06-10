using Microsoft.AspNetCore.Http;
using schoolapp.Infrastructure.Security.CurrentUserProvider;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace schoolapp.Infrastructure.Security.CurrentUserProvider
{
    public class UserProvider :IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new Exception();
            }

            var id = GetSingleClaimValue("id");
            //var id = Guid.Parse(GetSingleClaimValue("id"));

            var permissions = GetClaimValues("permissions");
            var roles = GetClaimValues(ClaimTypes.Role);
            // var policies = GetClaimValues(ClaimTypes.)
            var firstName = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
            var lastName = GetSingleClaimValue(ClaimTypes.Surname);
            var email = GetSingleClaimValue(ClaimTypes.Email);

            return new CurrentUser(id, firstName, lastName, email, permissions, roles);
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
