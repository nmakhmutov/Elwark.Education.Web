namespace Education.Client.Gateways.History.Home;

internal sealed record HistoryOverview(
    HistoryTopicSummary DailyTopic,
    HistoryTopicSummary[] Trends,
    HistoryTopicSummary[] TopFavorites,
    HistoryTopicSummary[] TopRatings,
    HistoryTopicSummary[] Recent
);
