using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record TimelineOverviewModel(
    string Id,
    EpochType Epoch,
    string Title,
    string Overview,
    ImageBundleModel Image,
    TimeSpan TimeToRead,
    double Popularity,
    HistoricalDateModel? Started,
    HistoricalDateModel? Finished
) : ArticleOverviewModel(Id, Epoch, Title, Overview, Image, TimeToRead, Popularity);
