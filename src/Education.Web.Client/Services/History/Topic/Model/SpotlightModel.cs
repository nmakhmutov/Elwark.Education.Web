namespace Education.Web.Client.Services.History.Topic.Model;

public sealed record SpotlightModel(
    TopicOverviewModel DailyTopic,
    TopicOverviewModel[] Trends,
    TopicOverviewModel[] TopBookmarked,
    TopicOverviewModel[] TopRatings,
    TopicOverviewModel[] Recent
);
