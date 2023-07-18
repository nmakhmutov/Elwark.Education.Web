using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.Article.Model;

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
