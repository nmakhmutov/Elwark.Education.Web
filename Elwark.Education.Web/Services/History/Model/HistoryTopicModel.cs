namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTopicModel(
        string Title,
        string Description,
        string? Image,
        HistoricalSegment? Segment,
        HistoryPeriodTitle Period,
        HistoryArticleItem[] Articles
    );
}