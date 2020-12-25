using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record SubjectStatisticsSummary(
        Subject Subject,
        PassedTests PassedTests,
        TimeSpan TimeSpent,
        Score Score,
        AnswerRatio AnswerRatio
    ) : StatisticsSummary(PassedTests, TimeSpent, Score, AnswerRatio);
}