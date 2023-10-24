using Microsoft.AspNetCore.Identity;
using schoolapp.Application.Common.Models;
using schoolapp.Infrastructure.Identity;

namespace schoolapp.Application.Identity;

public static class IdentityResultExtensions
{
    //public static Result<SchoolUser> ToApplicationResult(this IdentityResult result)
    //{
    //    return result.Succeeded
    //        ? Result<SchoolUser>.Success()
    //        : Result<SchoolUser>.Failure(result.Errors.Select(e => e.Description));
    //}

}
