namespace schoolapp.Infrastructure.Security.CurrentUserProvider;

public record CurrentUser(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles);