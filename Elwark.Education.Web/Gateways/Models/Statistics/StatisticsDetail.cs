using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record StatisticsDetail(
        long PassedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio,
        Ranking<long> ScoreRanking,
        Ranking<TimeSpan> TimeSpentRanking
    ) : StatisticsSummary(PassedTests, TimeSpent, Score, AnswerRatio);
}