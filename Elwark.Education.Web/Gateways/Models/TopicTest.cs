using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models.TestConclusion;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record TopicTest(
        TestStatus Status,
        TestDifficulty[] Difficulties,
        IDictionary<TestDifficulty, NumberOfTests> NumberOfTests,
        TestConclusionOverview[] Conclusions
    );
}
