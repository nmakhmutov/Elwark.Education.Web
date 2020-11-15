namespace Elwark.Education.Web.Services.History.Models
{
    public sealed record HistoryArticleItem(
        string TopicId,
        string ArticleId,
        string Title,
        string? Subtitle,
        string Image,
        ArticleType Type,
        ArticleTest Test
    );
}