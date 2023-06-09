using System.Security.Claims;

namespace Education.Web.Client.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static bool IsAuthenticated(this ClaimsPrincipal principal) =>
        principal.Identity?.IsAuthenticated ?? false;

    public static long GetId(this ClaimsPrincipal principal) =>
        principal.GetIdOrDefault() ?? throw new NullReferenceException("Claims doesn't contain 'sub'");

    public static long? GetIdOrDefault(this ClaimsPrincipal principal)
    {
        if (principal.Identity?.IsAuthenticated == false)
            return null;

        var sub = principal.FindFirst("sub")?.Value;
        return sub is null ? null : long.Parse(sub);
    }
}
