using System.Security.Claims;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetName(this ClaimsPrincipal principal) =>
            principal.FindFirst("name")?.Value;

        public static string GetNickname(this ClaimsPrincipal principal) =>
            principal.FindFirst("nickname")!.Value;
        
        public static string? GetImage(this ClaimsPrincipal principal) =>
            principal.FindFirst("picture")?.Value;
    }
}
