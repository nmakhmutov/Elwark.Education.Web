using Education.Web.Services.Model.Content;

namespace Education.Web.Services.History.Topic.Model;

public sealed record TopicDetailCompositionModel(
    HistoryTopicDetailModel Topic,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserTopicOverviewModel[] RelatedTopics
);
