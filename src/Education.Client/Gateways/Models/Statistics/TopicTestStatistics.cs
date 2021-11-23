using Education.Client.Gateways.Models.Progress;

namespace Education.Client.Gateways.Models.Statistics;

public sealed record TestStatistics(
    Score Score,
    AnswerRatio AnswerRatio,
    TimeSpent TimeSpent,
    NumberOfTests NumberOfTests,
    WeeklyProgress Progress
);
