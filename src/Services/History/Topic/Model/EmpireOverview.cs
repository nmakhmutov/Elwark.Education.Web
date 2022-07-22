namespace Education.Web.Services.History.Topic.Model;

public sealed record EmpireOverview(
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
