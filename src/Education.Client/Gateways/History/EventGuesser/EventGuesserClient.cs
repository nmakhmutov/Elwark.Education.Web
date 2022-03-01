using Education.Client.Gateways.History.EventGuesser.Model;
using Education.Client.Gateways.History.EventGuesser.Request;

namespace Education.Client.Gateways.History.EventGuesser;

internal sealed class EventGuesserClient : GatewayClient
{
    private readonly HttpClient _client;

    public EventGuesserClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestModel>> GetAsync() =>
        ExecuteAsync<TestModel>(ct => _client.GetAsync("history/event-guessers", ct));

    public Task<ApiResponse<TestBuilderModel>> GetBuilderAsync() =>
        ExecuteAsync<TestBuilderModel>(ct => _client.GetAsync("history/event-guessers/builder", ct));

    public Task<ApiResponse<ConclusionModel>> GetConclusionAsync() =>
        ExecuteAsync<ConclusionModel>(ct => _client.GetAsync("history/event-guessers/conclusion", ct));

    public Task<ApiResponse<TestModel>> CreateAsync(CreateRequest request) =>
        ExecuteAsync<TestModel>(ct => _client.PostAsync("history/event-guessers", CreateJson(request), ct));

    public Task<ApiResponse<CheckModel>> CheckAsync(CheckRequest request) =>
        ExecuteAsync<CheckModel>(ct => _client.PutAsync("history/event-guessers", CreateJson(request), ct));
}
