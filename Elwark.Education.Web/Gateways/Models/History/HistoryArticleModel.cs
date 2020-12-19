namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleModel(
        string Id,
        TopicTitle Topic,
        HistoryPeriodTitle Period,
        ContentType Type,
        string? Image,
        string Title,
        string? Subtitle,
        string Text,
        string? Footnotes,
        bool IsTestAvailable
    );
}