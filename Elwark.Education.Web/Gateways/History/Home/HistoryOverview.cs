namespace Elwark.Education.Web.Gateways.History.Home
{
    internal sealed record HistoryOverview(
        TopicSummary[] TrendingTopics,
        TopicSummary[] RecentTopics,
        TopicSummary[] HotTopics
    );
}
