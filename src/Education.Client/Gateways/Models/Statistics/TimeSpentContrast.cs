namespace Education.Client.Gateways.Models.Statistics;

public sealed record TimeSpentContrast(
    Contrast<TimeSpan> Total,
    Contrast<TimeSpan> Average,
    Contrast<TimeSpan> Min,
    Contrast<TimeSpan> Max
);
