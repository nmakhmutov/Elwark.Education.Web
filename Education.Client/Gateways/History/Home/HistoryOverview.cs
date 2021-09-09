namespace Education.Client.Gateways.History.Home
{
    internal sealed record HistoryOverview(
        TopicSummary DailyTopic,
        TopicSummary[] TrendingTopics,
        TopicSummary[] RecentTopics,
        TopicSummary[] HotTopics
    );
}
