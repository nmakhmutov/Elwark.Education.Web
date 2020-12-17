namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTopicModel(
        string Title,
        string Description,
        string Image,
        HistoricalSegment? Segment,
        HistoryPeriodTitle Period,
        HistoryArticleItem[] Articles
    );
}