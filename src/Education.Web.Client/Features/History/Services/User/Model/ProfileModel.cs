namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record ProfileModel(
    LevelModel Level,
    ulong TotalQuizzes,
    ulong TotalEventGuessers,
    UserArticleOverviewModel[] RecentArticles
);
