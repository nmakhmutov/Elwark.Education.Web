namespace Education.Web.Client.Services.Model.Statistics;

public sealed record AnswerRatioContrastModel(
    ContrastModel<uint> Questions,
    ContrastModel<uint> Answered,
    ContrastModel<uint> NotAnswered,
    ContrastModel<uint> Correct,
    ContrastModel<uint> Incorrect
);
