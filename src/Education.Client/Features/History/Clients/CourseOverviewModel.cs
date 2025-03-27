using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients;

public sealed record CourseOverviewModel(
    string Id,
    string Title,
    string Overview,
    ImageBundleModel Image,
    uint ArticleCount,
    double Popularity
);
