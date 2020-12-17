using System.Collections.Generic;
using Elwark.Education.Web.Gateways.Models.Statistics;

namespace Elwark.Education.Web.Gateways.Models
{
    internal sealed record SubjectAggregate(
        ContentStatistics Statistics,
        IEnumerable<TestConclusion.TestConclusion> TestConclusions
    );
}