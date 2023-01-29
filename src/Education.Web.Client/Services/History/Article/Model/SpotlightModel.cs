namespace Education.Web.Client.Services.History.Article.Model;

public sealed record SpotlightModel(
    ArticleOverviewModel DailyArticle,
    ArticleOverviewModel[] Trends,
    ArticleOverviewModel[] TopBookmarked,
    ArticleOverviewModel[] TopRatings,
    ArticleOverviewModel[] Recent
);
