using System;
using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    internal sealed record UserStatistics(
        ScoreStatistics Score,
        AnswerRatioStatistics AnswerRatio,
        TimeSpentStatistics TimeSpent,
        IDictionary<TestDifficulty, NumberOfTestsStatistics> NumberOfTests
    );

    internal sealed record Changes<T>(T Current, double Difference);

    internal sealed record ScoreStatistics(
        Score Total,
        ScoreProgress Progress,
        RankingItem<Score>[] Ranking
    );

    internal sealed record ScoreProgress(
        DateTime Starts,
        DateTime Ends,
        Changes<ulong> Total,
        Changes<uint> Questions,
        Changes<uint> NoMistakes,
        Changes<uint> Speed
    );


    internal sealed record AnswerRatioStatistics(
        AnswerRatio Total,
        AnswerRatioProgress Progress
    );

    internal sealed record AnswerRatioProgress(
        DateTime Starts,
        DateTime Ends,
        Changes<uint> Questions,
        Changes<uint> Answered,
        Changes<uint> NotAnswered,
        Changes<uint> Correct,
        Changes<uint> Incorrect
    );

    internal sealed record NumberOfTestsStatistics(
        NumberOfTests Total,
        NumberOfTestsProgress Progress,
        RankingItem<NumberOfTests>[] Ranking
    );

    internal sealed record NumberOfTestsProgress(
        DateTime Starts,
        DateTime Ends,
        Changes<uint> Total,
        Changes<uint> Completed,
        Changes<uint> TimeExceeded,
        Changes<uint> RepliesExceeded
    );
    
    internal sealed record TimeSpentStatistics(
        TimeSpan Total,
        TimeSpentProgress Progress,
        RankingItem<TimeSpan>[] Ranking
    );

    internal sealed record TimeSpentProgress(DateTime Starts, DateTime Ends, Changes<TimeSpan> TimeSpent);
}
