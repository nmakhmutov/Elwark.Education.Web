using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleTest(
        PermissionStatus Status,
        CompletedTimes CompletedTimes,
        TestConclusionOverview[] Conclusions
    );
}
