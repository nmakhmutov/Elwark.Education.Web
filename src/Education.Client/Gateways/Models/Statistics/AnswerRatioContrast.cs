namespace Education.Client.Gateways.Models.Statistics;

public sealed record AnswerRatioContrast(
    Contrast<uint> Questions,
    Contrast<uint> Answered,
    Contrast<uint> NotAnswered,
    Contrast<uint> Correct,
    Contrast<uint> Incorrect
);
