using Elwark.Education.Web.Gateways.Models.Test;

namespace Elwark.Education.Web.Gateways.History.Home
{
    internal sealed record HistoryOverview(
        TestStatus TestStatus,
        TopicSummary DailyTopic,
        TopicSummary[] TrendingTopics,
        TopicSummary[] RecentTopics,
        TopicSummary[] HotTopics
    );
}
