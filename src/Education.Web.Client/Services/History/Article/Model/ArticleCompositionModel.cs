using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Services.History.Article.Model;

public sealed record ArticleCompositionModel(
    ArticleDetail Article,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserArticleOverviewModel[] RelatedArticles
);
