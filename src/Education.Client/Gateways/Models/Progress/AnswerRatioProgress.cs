namespace Education.Client.Gateways.Models.Progress;

public sealed record AnswerRatioProgress(
    Contrast<uint> Questions,
    Contrast<uint> Answered,
    Contrast<uint> NotAnswered,
    Contrast<uint> Correct,
    Contrast<uint> Incorrect
);
