namespace Education.Client.Gateways.Models.Statistics;

public sealed record TimeSpentContrastModel(
    ContrastModel<TimeSpan> Total,
    ContrastModel<TimeSpan> Average,
    ContrastModel<TimeSpan> Min,
    ContrastModel<TimeSpan> Max
);
