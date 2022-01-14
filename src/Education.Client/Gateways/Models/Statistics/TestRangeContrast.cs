namespace Education.Client.Gateways.Models.Statistics;

public sealed record TestRangeContrast(
    DateTime Starts,
    DateTime Ends,
    ScoreContrast Score,
    AnswerRatioContrast AnswerRatio,
    TimeSpentContrast TimeSpent,
    NumberOfTestsContrast NumberOfTests
);
