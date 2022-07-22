namespace Education.Web.Services.Model.Statistics;

public sealed record ScoreContrastModel(
    ContrastModel<ulong> Total,
    ContrastModel<uint> Questions,
    ContrastModel<uint> NoMistakes,
    ContrastModel<uint> Speed
);
