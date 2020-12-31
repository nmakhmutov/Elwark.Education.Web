namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleItem(
        string Id,
        string Title,
        string? Subtitle,
        string? Image,
        ContentPermission Permission,
        ArticleTest Test
    );
}