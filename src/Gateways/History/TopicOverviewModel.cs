using Education.Web.Gateways.Models.Content;

namespace Education.Web.Gateways.History;

public sealed record TopicOverviewModel(
    string Id,
    string Title,
    string Overview,
    string Image,
    EpochType Epoch,
    ContentRatingModel Rating,
    bool HasEasyTest,
    bool HasHardTest
);
