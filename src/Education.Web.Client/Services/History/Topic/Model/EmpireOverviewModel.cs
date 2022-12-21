namespace Education.Web.Client.Services.History.Topic.Model;

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
