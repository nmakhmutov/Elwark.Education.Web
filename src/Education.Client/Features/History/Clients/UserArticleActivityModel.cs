namespace Education.Client.Features.History.Clients;

public sealed record UserArticleActivityModel(
    ArticleLearningStatus Status,
    bool IsBookmarked,
    bool? IsLiked,
    ContentQuality Quality,
    bool? IsEasyQuizCompleted,
    bool? IsHardQuizCompleted,
    bool? IsExpertQuizCompleted
);
