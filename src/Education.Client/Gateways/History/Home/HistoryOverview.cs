namespace Education.Client.Gateways.History.Home;

internal sealed record HistoryOverview(
    TopicSummary DailyTopic,
    TopicSummary[] Trends,
    TopicSummary[] TopFavorites,
    TopicSummary[] TopRatings,
    TopicSummary[] Recent
);
