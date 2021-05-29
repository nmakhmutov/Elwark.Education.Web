using Elwark.Education.Web.Gateways.Models.Statistics;

namespace Elwark.Education.Web.Gateways.History.Me
{
    public sealed record UserStatistics(TestStatistics EasyTest, TestStatistics HardTest);
}
