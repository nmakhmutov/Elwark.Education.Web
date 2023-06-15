namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record UserArticleDetailModel(
    ArticleDetail Article,
    UserArticleActivityModel? Activity,
    bool HasEasyQuiz,
    bool HasHardQuiz
);
