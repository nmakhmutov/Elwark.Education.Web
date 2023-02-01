using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Services.History;

public sealed record ArticleOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    EpochType Epoch,
    ContentRatingModel Rating
);
