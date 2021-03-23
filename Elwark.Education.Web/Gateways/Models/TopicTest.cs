using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record TopicTest(
        PermissionStatus Status,
        TopicProgress Progress,
        TestConclusionOverview[] Conclusions
    );
}
