using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record ArticleTest(
        PermissionStatus Status,
        uint QuantityCompletedTimes,
        TestConclusionOverview[] Conclusions
    );
}
