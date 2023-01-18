using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.History.Topic.Model;

public sealed record TopicDetailCompositionModel(
    HistoryTopicDetail Topic,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserTopicOverviewModel[] RelatedTopics
);
