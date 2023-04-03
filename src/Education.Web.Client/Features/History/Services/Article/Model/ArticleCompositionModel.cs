namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record ArticleCompositionModel(
    ArticleDetail Article,
    UserArticleActivityModel UserActivity,
    bool HasQuiz,
    UserArticleOverviewModel[] RelatedArticles
);
