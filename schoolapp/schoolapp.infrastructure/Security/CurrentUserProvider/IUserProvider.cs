namespace schoolapp.Infrastructure.Security.CurrentUserProvider
{
    public interface IUserProvider
    {
        CurrentUser GetCurrentUser();
    }
}
