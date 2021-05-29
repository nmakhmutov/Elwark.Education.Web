using System.Net.Http;
using Elwark.Education.Web.Gateways.History.Epoch;
using Elwark.Education.Web.Gateways.History.Home;
using Elwark.Education.Web.Gateways.History.Me;
using Elwark.Education.Web.Gateways.History.Test;
using Elwark.Education.Web.Gateways.History.Topic;

namespace Elwark.Education.Web.Gateways.History
{
    internal interface IHistoryClient
    {
        public EpochClient Epoch { get; }

        public HomeClient Home { get; }

        public MeClient Me { get; }

        public TestClient Test { get; }

        public TopicClient Topic { get; }
    }

    internal sealed class HistoryClient : GatewayClient, IHistoryClient
    {
        public HistoryClient(HttpClient client)
        {
            Epoch = new EpochClient(client);
            Home = new HomeClient(client);
            Me = new MeClient(client);
            Test = new TestClient(client);
            Topic = new TopicClient(client);
        }

        public EpochClient Epoch { get; }

        public HomeClient Home { get; }

        public MeClient Me { get; }

        public TestClient Test { get; }

        public TopicClient Topic { get; }
    }
}
