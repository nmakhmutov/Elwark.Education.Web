using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TopicStatistics(
        PassedTests PassedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio,
        TopicsState TopicsState,
        WeeklyDifference WeeklyDifference,
        RankingItem<ulong>[] ScoreRanking,
        RankingItem<TimeSpan>[] TimeSpentRanking,
        RankingItem<uint>[] TestPassedTimesRanking
    ) : StatisticsSummary(PassedTests, TimeSpent, Score, AnswerRatio);
}