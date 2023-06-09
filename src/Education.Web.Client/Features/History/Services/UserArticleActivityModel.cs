namespace Education.Web.Client.Features.History.Services;

public sealed record UserArticleActivityModel(
    bool IsBookmarked,
    bool? IsCompleted,
    bool? IsLiked,
    uint TotalQuizzes
);