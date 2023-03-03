namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record ArticleCompositionModel(
    ArticleDetail Article,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserArticleOverviewModel[] RelatedArticles
);
