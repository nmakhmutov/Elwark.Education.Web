namespace Education.Client.Gateways.History.Empires.Model;

public sealed record EmpireOverview(
    string Id,
    string Title,
    string Overview,
    string Image,
    HistoricalDateModel? Founded,
    HistoricalDateModel? Dissolved,
    uint MaxArea,
    uint MaxPopulation
);
