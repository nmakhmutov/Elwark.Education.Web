using Elwark.Education.Web.Gateways.History.Epoch;
using Elwark.Education.Web.Gateways.Models.Content;

namespace Elwark.Education.Web.Gateways.History
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
