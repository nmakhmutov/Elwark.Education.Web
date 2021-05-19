using Elwark.Education.Web.Gateways.Models.History;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record TopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        bool IsFavorite,
        EpochType Epoch,
        ContentRating Rating
    );
}
