namespace Education.Web.Client.Features.History.Clients.Article.Model;

public sealed record UserArticleDetailModel(
    ArticleDetail Article,
    UserArticleActivityModel? Activity,
    bool HasEasyQuiz,
    bool HasHardQuiz
);
