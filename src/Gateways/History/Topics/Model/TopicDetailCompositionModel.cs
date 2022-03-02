using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.History.Topics.Model;

internal sealed record TopicDetailCompositionModel(
    HistoryTopicDetailModel Topic,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool IsTestAvailable,
    UserTopicOverviewModel[] RelatedTopics
);
