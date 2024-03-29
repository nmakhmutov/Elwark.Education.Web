using Education.Client.Models.Content;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record EmpireOverviewModel(
    string Id,
    string Title,
    string Overview,
    ImageBundleModel Image,
    HistoricalDateModel? Founded,
    HistoricalDateModel? Dissolved,
    uint? Duration,
    uint MaxArea,
    uint MaxPopulation
);
