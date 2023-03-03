using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services;

public sealed record CourseOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    ContentRatingModel Rating
);