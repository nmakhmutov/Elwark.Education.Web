using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public record StatisticsSummary(long PassedTests, TimeSpan ElapsedTime, Score Score, AnswerRatio AnswerRatio);
}