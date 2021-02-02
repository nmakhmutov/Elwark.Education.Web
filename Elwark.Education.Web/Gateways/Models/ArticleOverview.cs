namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleOverview(
        string Id,
        string Title,
        string Overview,
        string? Image,
        ContentPermission Permission
    );
}