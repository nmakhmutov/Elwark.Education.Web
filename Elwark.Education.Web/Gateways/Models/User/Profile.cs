using System;
using Elwark.Education.Web.Gateways.Models.Statistics;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record CurrentTest(string Id, Subject Subject, string Title, DateTime ExpiredAt);

    public sealed record RestrictionItem(int Quantity, DateTime? RestoreAt);

    public sealed record Restriction(Subject Subject, RestrictionItem TestCreation, RestrictionItem Answer);

    public sealed record UserStatistics(StatisticsSummary Summary, SubjectStatisticsSummary[] Subjects);

    public sealed record Profile(CurrentTest[] CurrentTests, Restriction[] Restrictions, UserStatistics Statistics);
}