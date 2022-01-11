using Education.Client.Gateways.Models.Content;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Topic;

internal sealed record TopicDetailComposition(
    TopicDetail Topic,
    TopicTest Test,
    UserContentRating Rating,
    UserTopicProgress Progress,
    bool IsFavorite,
    UserTopicSummary[] RelatedTopics
);
