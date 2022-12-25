using Education.Web.Client.Services.Model.Content;

namespace Education.Web.Client.Services.History;

public sealed record TopicOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    EpochType Epoch,
    ContentRatingModel Rating
);