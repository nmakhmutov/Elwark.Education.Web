using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TopicStatistics(
        CompletedTests CompletedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio,
        WeeklyDifference WeeklyDifference,
        RankingItem<ulong>[] ScoreRanking,
        RankingItem<TimeSpan>[] TimeSpentRanking,
        RankingItem<uint>[] CompletedTimesRanking
    ) : StatisticsSummary(CompletedTests, TimeSpent, Score, AnswerRatio);
}
