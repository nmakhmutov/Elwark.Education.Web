using System;

namespace Education.Client.Gateways.Models.Progress
{
    public sealed record WeeklyProgress(
        DateTime Starts,
        DateTime Ends,
        ScoreProgress Score,
        AnswerRatioProgress AnswerRatio,
        TimeSpentProgress TimeSpent,
        NumberOfTestsProgress NumberOfTests
    );
}
