namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record SpotlightModel(
    ArticleOverviewModel DailyArticle,
    ArticleOverviewModel[] Trends,
    ArticleOverviewModel[] TopBookmarked,
    ArticleOverviewModel[] TopRatings,
    ArticleOverviewModel[] Recent
);
