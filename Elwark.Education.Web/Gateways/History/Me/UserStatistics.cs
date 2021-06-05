using Elwark.Education.Web.Gateways.Models;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record UserStatistics(TestOverview EasyTest, TestOverview HardTest);
    
    public sealed record TestOverview(NumberOfTests NumberOfTests, Score Score);
}
