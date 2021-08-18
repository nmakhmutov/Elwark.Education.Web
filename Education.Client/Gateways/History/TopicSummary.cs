using Education.Client.Gateways.Models.Content;

namespace Education.Client.Gateways.History
{
    public sealed record TopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        EpochType Epoch,
        ContentRating Rating
    );
}
