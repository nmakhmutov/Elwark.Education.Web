namespace Education.Web.Services.Model.Statistics;

public sealed record TimeSpentContrastModel(
    ContrastModel<TimeSpan> Total,
    ContrastModel<TimeSpan> Average,
    ContrastModel<TimeSpan> Min,
    ContrastModel<TimeSpan> Max
);
