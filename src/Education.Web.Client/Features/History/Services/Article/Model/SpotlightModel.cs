namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record SpotlightModel(
    ArticleOverviewModel DailyArticle,
    ArticleOverviewModel[] Trending,
    ArticleOverviewModel[] Popular,
    ArticleOverviewModel[] Recent
);
