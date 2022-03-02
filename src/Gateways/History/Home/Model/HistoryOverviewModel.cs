namespace Education.Web.Gateways.History.Home.Model;

internal sealed record HistoryOverviewModel(
    TopicOverviewModel DailyTopic,
    TopicOverviewModel[] Trends,
    TopicOverviewModel[] TopFavorites,
    TopicOverviewModel[] TopRatings,
    TopicOverviewModel[] Recent
);