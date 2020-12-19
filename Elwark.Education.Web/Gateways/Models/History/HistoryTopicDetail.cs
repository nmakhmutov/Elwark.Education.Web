namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryDateRange? Segment,
        HistoryPeriodTitle Period,
        HistoryArticleItem[] Articles
    );
}