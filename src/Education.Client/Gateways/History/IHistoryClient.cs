using Education.Client.Gateways.History.Empires;
using Education.Client.Gateways.History.EventGuesser;
using Education.Client.Gateways.History.Home;
using Education.Client.Gateways.History.Tests;
using Education.Client.Gateways.History.Topics;
using Education.Client.Gateways.History.Users;

namespace Education.Client.Gateways.History;

internal interface IHistoryClient
{
    public EmpireClient Empire { get; }
    
    public EventGuesserClient EventGuesser { get; }

    public HomeClient Home { get; }

    public UserClient User { get; }

    public TestClient Test { get; }

    public TopicClient Topic { get; }
}

internal sealed class HistoryClient : GatewayClient, IHistoryClient
{
    public HistoryClient(HttpClient client)
    {
        Empire = new EmpireClient(client);
        EventGuesser = new EventGuesserClient(client);
        Home = new HomeClient(client);
        User = new UserClient(client);
        Test = new TestClient(client);
        Topic = new TopicClient(client);
    }

    public EmpireClient Empire { get; }

    public EventGuesserClient EventGuesser { get; }

    public HomeClient Home { get; }

    public UserClient User { get; }

    public TestClient Test { get; }

    public TopicClient Topic { get; }
}
