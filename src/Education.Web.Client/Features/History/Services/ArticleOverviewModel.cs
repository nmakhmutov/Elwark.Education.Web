using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services;

public sealed record ArticleOverviewModel(
    string Id,
    EpochType Epoch,
    string Title,
    string Overview,
    string ThumbnailUrl,
    TimeSpan TimeToRead,
    ContentRatingModel Rating
);
