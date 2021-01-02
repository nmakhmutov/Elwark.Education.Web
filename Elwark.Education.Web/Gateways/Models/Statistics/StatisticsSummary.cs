using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public record StatisticsSummary(CompletedTests CompletedTests, TimeSpan TimeSpent, Score Score, AnswerRatio AnswerRatio);
}