using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record TopicStatistics(
        long PassedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio,
        ProgressStatistics Progress,
        RankingItem<long>[] ScoreRanking,
        RankingItem<TimeSpan>[] TimeSpentRanking,
        RankingItem<int>[] TestPassedTimesRanking
    ) : StatisticsSummary(PassedTests, TimeSpent, Score, AnswerRatio);
}