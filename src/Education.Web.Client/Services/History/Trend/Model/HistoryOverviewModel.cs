namespace Education.Web.Client.Services.History.Trend.Model;

internal sealed record HistoryOverviewModel(
    TopicOverviewModel DailyTopic,
    TopicOverviewModel[] Trends,
    TopicOverviewModel[] TopBookmarked,
    TopicOverviewModel[] TopRatings,
    TopicOverviewModel[] Recent
);
