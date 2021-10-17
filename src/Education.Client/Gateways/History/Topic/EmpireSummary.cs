namespace Education.Client.Gateways.History.Topic;

public sealed record EmpireSummary(
    string Id,
    string Title,
    string Overview,
    string Image,
    HistoricDate? Founded,
    HistoricDate? Ended,
    uint MaxArea,
    uint MaxPopulation
);
