using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.History.EventGuesser
{
    internal sealed class EventGuesserClient : GatewayClient
    {
        private readonly HttpClient _client;

        public EventGuesserClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<EventGuesserTestModel>> GetAsync() =>
            ExecuteAsync<EventGuesserTestModel>(() => _client.GetAsync("history/event-guesser"));

        public Task<ApiResponse<EventGuesserConclusionModel>> ConcludeAsync() =>
            ExecuteAsync<EventGuesserConclusionModel>(() => _client.GetAsync("history/event-guesser/conclusion"));

        public Task<ApiResponse<EventGuesserTestModel>> CreateAsync(EventGuesserCreateRequest request) =>
            ExecuteAsync<EventGuesserTestModel>(() => _client.PostAsync("history/event-guesser", ToJson(request)));

        public Task<ApiResponse<EventGuesserCheckModel>> CheckAsync(EventGuesserCheckRequest request) =>
            ExecuteAsync<EventGuesserCheckModel>(() => _client.PutAsync("history/event-guesser", ToJson(request)));
    }
    
    public sealed record EventGuesserCreateRequest(int Questions, EpochType Epoch);

    public sealed record EventGuesserCheckRequest(string Id, int Year, uint? Month, uint? Day);
}
