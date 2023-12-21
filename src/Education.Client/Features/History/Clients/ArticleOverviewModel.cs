using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients;

public sealed record ArticleOverviewModel(
    string Id,
    EpochType Epoch,
    string Title,
    string Overview,
    string ThumbnailUrl,
    TimeSpan TimeToRead,
    ContentRatingModel Rating
);
