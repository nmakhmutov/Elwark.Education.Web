using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.History.Topic.Model;

public sealed record TopicCompositionModel(
    TopicDetail Topic,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserTopicOverviewModel[] RelatedTopics
);
