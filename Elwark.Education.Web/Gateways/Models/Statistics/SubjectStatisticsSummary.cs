using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record SubjectStatisticsSummary(
        SubjectType SubjectType,
        CompletedTests CompletedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio
    ) : StatisticsSummary(CompletedTests, TimeSpent, Score, AnswerRatio);
}