using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History
{
    internal sealed record UserTopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        EpochType Epoch,
        bool IsFavorite,
        UserContentRating Rating,
        UserTopicProgress Progress
    );
}
