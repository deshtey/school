using schoolapp.Application.Common.Models;

namespace schoolapp.Infrastructure.Security.CurrentUserProvider
{
    public interface IUserProvider
    {
        Result<CurrentUser> GetCurrentUser();
    }
}
