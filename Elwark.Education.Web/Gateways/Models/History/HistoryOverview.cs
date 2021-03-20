namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryOverview(
        HistoryPeriodModel[] Periods,
        TopicOverview[] TrendingTopics, 
        TopicOverview[] RecentTopics,
        TopicOverview[] HotTopics
    );
}
