namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleDetail(
        string Id,
        TopicTitle Topic,
        HistoryPeriodType Period,
        ContentType Type,
        ArticleTest? Test,
        string? Image,
        string Title,
        string Text,
        string? Footnotes,
        AdjacentArticles Adjacent
    );
}