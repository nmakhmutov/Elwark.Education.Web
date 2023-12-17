namespace Education.Web.Client.Features.History.Clients;

public sealed record UserArticleActivityModel(
    LearningStatus Status,
    bool IsBookmarked,
    bool? IsLiked,
    uint EasyQuizzes,
    uint HardQuizzes
);
