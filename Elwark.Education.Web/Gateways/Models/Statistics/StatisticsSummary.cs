using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public record StatisticsSummary(PassedTests PassedTests, TimeSpan TimeSpent, Score Score, AnswerRatio AnswerRatio);
}