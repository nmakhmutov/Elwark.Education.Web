using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Home
{
    internal sealed record HistoryOverview(
        TestStatus TestStatus,
        TopicSummary DailyTopic,
        TopicSummary[] TrendingTopics,
        TopicSummary[] RecentTopics,
        TopicSummary[] HotTopics
    );
}
