using Education.Web.Services.Model.Content;

namespace Education.Web.Services.History;

public sealed record TopicOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    EpochType Epoch,
    ContentRatingModel Rating
);
