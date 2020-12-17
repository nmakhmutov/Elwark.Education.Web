using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record SubjectStatisticsSummary(
        Subject Subject,
        long PassedTests,
        TimeSpan ElapsedTime,
        Score Score,
        AnswerRatio AnswerRatio
    ) : StatisticsSummary(PassedTests, ElapsedTime, Score, AnswerRatio);
}