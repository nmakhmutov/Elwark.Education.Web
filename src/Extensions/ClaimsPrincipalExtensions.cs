using System.Security.Claims;

namespace Education.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static long GetId(this ClaimsPrincipal principal)
    {
        var sub = principal.FindFirst("sub")?.Value ?? throw new NullReferenceException("Claims doesn't contain 'sub'");
        return long.Parse(sub);
    }
}
