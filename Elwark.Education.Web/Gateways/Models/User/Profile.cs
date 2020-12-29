using System;
using Elwark.Education.Web.Gateways.Models.Statistics;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record CurrentTest(string Id, Subject Subject, string Title, DateTime ExpiredAt);

    public sealed record Restriction(int Quantity, DateTime? RestoreAt);

    public sealed record Subscription(
        Subject Subject,
        SubscriptionType Type,
        DateTime? ExpiredAt,
        Restriction TestCreating,
        Restriction TestAnswering
    );

    public sealed record UserStatistics(StatisticsSummary Summary, SubjectStatisticsSummary[] Subjects);

    public sealed record Profile(CurrentTest[] CurrentTests, Subscription[] Subscriptions, UserStatistics Statistics);
}