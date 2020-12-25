using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record ArticleStatistics(
        PassedTests PassedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio,
        WeeklyDifference WeeklyDifference,
        RankingItem<long>[] ScoreRanking,
        RankingItem<TimeSpan>[] TimeSpentRanking,
        RankingItem<int>[] TestPassedTimesRanking
    ) : StatisticsSummary(PassedTests, TimeSpent, Score, AnswerRatio);
}