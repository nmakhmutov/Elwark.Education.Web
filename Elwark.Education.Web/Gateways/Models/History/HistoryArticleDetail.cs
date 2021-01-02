namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleDetail(
        string Id,
        TopicTitle Topic,
        HistoryPeriodTitle Period,
        ContentType Type,
        ArticleTest? Test,
        string? Image,
        string Title,
        string? Subtitle,
        string Text,
        string? Footnotes
    );
}