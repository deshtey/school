using Microsoft.AspNetCore.Authorization;
namespace schoolapp.Infrastructure.Security.AuthorizationFilters
{

    public class MenuAuthorizationRequirement : IAuthorizationRequirement
    {
        public string MenuName { get; }

        public MenuAuthorizationRequirement(string menuName)
        {
            MenuName = menuName;
        }
    }
}
