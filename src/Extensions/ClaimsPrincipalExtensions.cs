using System.Security.Claims;

namespace Education.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static long GetId(this ClaimsPrincipal principal)
    {
        var sub = principal.FindFirst("sub")?.Value ?? throw new NullReferenceException("Claims doesn't contain 'sub'");
        return long.Parse(sub);
    }

    [Obsolete]
    public static string? GetName(this ClaimsPrincipal principal) =>
        principal.FindFirst("name")?.Value;

    [Obsolete]
    public static string GetNickname(this ClaimsPrincipal principal) =>
        principal.FindFirst("nickname")?.Value ?? throw new NullReferenceException("Claims doesn't contain nickname");

    [Obsolete]
    public static string? GetImage(this ClaimsPrincipal principal) =>
        principal.FindFirst("picture")?.Value;
}
