namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryOverview(
        TopicSummary[] TrendingTopics, 
        TopicSummary[] RecentTopics,
        TopicSummary[] HotTopics
    );
}
