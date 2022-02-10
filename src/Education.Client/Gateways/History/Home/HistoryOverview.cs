namespace Education.Client.Gateways.History.Home;

internal sealed record HistoryOverview(
    HistoryTopicOverview DailyTopic,
    HistoryTopicOverview[] Trends,
    HistoryTopicOverview[] TopFavorites,
    HistoryTopicOverview[] TopRatings,
    HistoryTopicOverview[] Recent
);
