namespace Education.Web.Services.History.Trend.Model;

internal sealed record HistoryOverviewModel(
    TopicOverviewModel DailyTopic,
    TopicOverviewModel[] Trends,
    TopicOverviewModel[] TopFavorites,
    TopicOverviewModel[] TopRatings,
    TopicOverviewModel[] Recent
);
