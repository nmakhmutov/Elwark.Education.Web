using Elwark.Education.Web.Gateways.History.Epoch;
using Elwark.Education.Web.Gateways.Models.Content;

namespace Elwark.Education.Web.Gateways.History
{
    public record TopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        bool IsFavorite,
        EpochType Epoch,
        ContentRating Rating
    );
}
