namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record EmpireOverviewModel(
    string Id,
    string Title,
    string Overview,
    string ThumbnailUrl,
    HistoricalDateModel? Founded,
    HistoricalDateModel? Dissolved,
    uint? Duration,
    uint MaxArea,
    uint MaxPopulation
);
