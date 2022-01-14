using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.History.Topic;

internal sealed record TopicDetailComposition(
    HistoryTopicDetail Topic,
    ContentRating Rating,
    TopicAvailableTest Test,
    UserTestPermission UserPermission,
    UserActivitySummary UserActivity,
    HistoryUserTopicSummary[] RelatedTopics
);
