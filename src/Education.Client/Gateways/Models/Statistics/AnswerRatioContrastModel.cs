namespace Education.Client.Gateways.Models.Statistics;

public sealed record AnswerRatioContrastModel(
    ContrastModel<uint> Questions,
    ContrastModel<uint> Answered,
    ContrastModel<uint> NotAnswered,
    ContrastModel<uint> Correct,
    ContrastModel<uint> Incorrect
);
