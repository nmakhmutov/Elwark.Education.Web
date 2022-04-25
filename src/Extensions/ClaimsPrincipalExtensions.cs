using System.Security.Claims;

namespace Education.Web.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static long GetId(this ClaimsPrincipal principal) =>
        long.Parse(principal.FindFirst("sub")?.Value ?? string.Empty);
    
    public static string? GetName(this ClaimsPrincipal principal) =>
        principal.FindFirst("name")?.Value;

    public static string GetNickname(this ClaimsPrincipal principal) =>
        principal.FindFirst("nickname")!.Value;

    public static string? GetImage(this ClaimsPrincipal principal) =>
        principal.FindFirst("picture")?.Value;
}
