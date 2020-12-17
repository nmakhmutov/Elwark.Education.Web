namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleItem(
        string ArticleId,
        string Title,
        string? Subtitle,
        string? Image,
        ContentType Type,
        bool IsTestAvailable,
        ArticleProgress? Progress
    );
}