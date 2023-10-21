using Microsoft.AspNetCore.Identity;

namespace schoolapp.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result<ApplicationUser> ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result<ApplicationUser>
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
