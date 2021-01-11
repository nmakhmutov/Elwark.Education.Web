using Elwark.Education.Web.Gateways.Models.Statistics;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record UserStatistics(StatisticsSummary Summary, SubjectStatisticsSummary[] Subjects);
}