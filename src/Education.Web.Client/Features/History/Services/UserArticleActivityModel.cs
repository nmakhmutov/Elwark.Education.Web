namespace Education.Web.Client.Features.History.Services;

public sealed record UserArticleActivityModel(
    LearningStatus Status,
    bool IsBookmarked,
    bool? IsLiked,
    uint EasyQuizzes,
    uint HardQuizzes
);
