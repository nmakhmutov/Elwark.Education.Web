namespace Education.Client.Gateways.History.Topic;

public sealed record EmpireOverview(
    string Id,
    string Title,
    string Overview,
    string Image,
    HistoricalDate? Founded,
    HistoricalDate? Dissolved,
    uint MaxArea,
    uint MaxPopulation
);
