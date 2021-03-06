using System.Net.Http;
using Education.Client.Gateways.History.Epoch;
using Education.Client.Gateways.History.Home;
using Education.Client.Gateways.History.Me;
using Education.Client.Gateways.History.Test;
using Education.Client.Gateways.History.Topic;

namespace Education.Client.Gateways.History
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
