using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record TimelineOverviewModel(
    string Id,
    EpochType Epoch,
    string Title,
    string Overview,
    string ThumbnailUrl,
    TimeSpan TimeToRead,
    ContentRatingModel Rating,
    HistoricalDateModel? Started,
    HistoricalDateModel? Finished
);
