namespace schoolapp.Infrastructure.Security.CurrentUserProvider;

public interface IUserService
{
    Task<bool> AssignRoleToUserAsync(string userId, string roleName);
    Task<bool> CreateRoleAsync(string roleName);
    Task<IEnumerable<string>> GetRolesAsync();
    Task<IEnumerable<string>> GetUserRolesAsync(string userId);
}