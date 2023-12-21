using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients;

public sealed record CourseOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    uint ArticleCount,
    ContentRatingModel Rating
);
