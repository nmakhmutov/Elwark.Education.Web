using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History.Topics.Model;

internal sealed record TopicDetailCompositionModel(
    HistoryTopicDetailModel Topic,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool IsTestAvailable,
    UserTopicOverviewModel[] RelatedTopics
);
