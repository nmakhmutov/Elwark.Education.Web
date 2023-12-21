namespace Education.Client.Features.History.Clients;

public sealed record UserArticleOverviewModel(
    ArticleOverviewModel Article,
    UserArticleActivityModel? Activity,
    bool HasQuiz
);
