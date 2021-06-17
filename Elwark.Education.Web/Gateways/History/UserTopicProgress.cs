using System;

namespace Elwark.Education.Web.Gateways.History
{
    public sealed record UserTopicProgress(uint PassedTests, TimeSpan TimeSpent);
}
