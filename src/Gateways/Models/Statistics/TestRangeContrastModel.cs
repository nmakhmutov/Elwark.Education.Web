namespace Education.Web.Gateways.Models.Statistics;

public sealed record TestRangeContrastModel(
    DateOnly Starts,
    DateOnly Ends,
    ScoreContrastModel Score,
    AnswerRatioContrastModel AnswerRatio,
    TimeSpentContrastModel TimeSpent,
    NumberOfTestsContrastModel NumberOfTests
);
