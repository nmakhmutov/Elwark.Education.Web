namespace Education.Web.Client.Features.History.Services;

public sealed record UserActivityOverviewModel(
    ulong PassedQuizzes,
    TimeSpan TimeSpent,
    bool IsBookmarked,
    bool? IsLiked
);
