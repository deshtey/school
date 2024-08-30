using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using schoolapp.Application.Common.Interfaces;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Infrastructure.Security.AuthorizationFilters
{
    public class MenuAuthorizationHandler : AuthorizationHandler<MenuAuthorizationRequirement>
    {
        private readonly ISchoolDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MenuAuthorizationHandler(ISchoolDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MenuAuthorizationRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }

            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var hasAccess = await _context.RolePermissions
                .AnyAsync(rmp => userRoles.Contains(rmp.RoleId) && rmp.Permission.Name == requirement.MenuName);

            if (hasAccess)
            {
                context.Succeed(requirement);
            }
        }
    }
}
