namespace Education.Client.Features.History.Clients;

public sealed record UserArticleActivityModel(
    ArticleLearningStatus Status,
    bool IsBookmarked,
    bool? IsLiked,
    uint EasyQuizzes,
    uint HardQuizzes
);
