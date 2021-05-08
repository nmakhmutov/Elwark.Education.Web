using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record UserStatistics(
        Difference<TimeSpan, TimeSpan> TimeSpent,
        ScoreStatistics Score,
        AnswerRatioStatistics AnswerRatio,
        Dictionary<TestDifficulty, NumberOfTestsStatistics> NumberOfTests,
        RankingItem<ulong>[] ScoreRanking,
        RankingItem<TimeSpan>[] TimeSpentRanking,
        RankingItem<uint>[] CompletedTimesRanking
    );

    public sealed record Difference<TValue, TChanges>(TValue Total, TValue Current, TChanges Changes);

    public sealed record ScoreStatistics(Difference<ulong, long> Total, uint Questions, uint NoMistakes, uint Speed);

    public sealed record AnswerRatioStatistics(
        Difference<uint, int> Questions,
        uint Answered,
        uint NotAnswered,
        uint Correct,
        uint Incorrect
    );

    public sealed record NumberOfTestsStatistics(
        Difference<uint, int> Total,
        uint Completed,
        uint TimeExceeded,
        uint RepliesExceeded
    );
}
