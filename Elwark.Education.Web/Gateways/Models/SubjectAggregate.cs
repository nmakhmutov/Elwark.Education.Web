using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models.Statistics;

namespace Elwark.Education.Web.Gateways.Models
{
    public sealed record SubjectAggregate(
        ContentStatistics Statistics,
        IEnumerable<TestConclusion.TestConclusion> TestConclusions
    );
}