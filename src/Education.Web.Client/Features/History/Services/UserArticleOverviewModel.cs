namespace Education.Web.Client.Features.History.Services;

public sealed record UserArticleOverviewModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel? Activity,
    bool HasQuiz
);
