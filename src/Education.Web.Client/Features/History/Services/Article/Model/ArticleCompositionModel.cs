using Education.Web.Client.Models.Content;

namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record ArticleCompositionModel(
    ArticleDetail Article,
    ContentRatingModel Rating,
    UserActivityOverviewModel UserActivity,
    bool HasTest,
    UserArticleOverviewModel[] RelatedArticles
);
