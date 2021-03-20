namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleDetail(
        string Id,
        TopicTitle Topic,
        HistoryPeriodType Period,
        ContentType Type,
        ArticleTest? Test,
        string? Image,
        string Overview,
        string Title,
        string Text,
        UserContentRating Rating,
        Infobox[] InfoBoxes,
        ArticleOverview[] Contents
    );
}
