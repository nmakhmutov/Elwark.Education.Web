namespace Education.Web.Gateways.Models.Statistics;

public sealed record TimeSpentContrastModel(
    ContrastModel<TimeSpan> Total,
    ContrastModel<TimeSpan> Average,
    ContrastModel<TimeSpan> Min,
    ContrastModel<TimeSpan> Max
);
