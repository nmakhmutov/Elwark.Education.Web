using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.History.EventGuesser.Models;
using Education.Client.Gateways.History.EventGuesser.Requests;

namespace Education.Client.Gateways.History.EventGuesser;

internal sealed class EventGuesserClient : GatewayClient
{
    private readonly HttpClient _client;

    public EventGuesserClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestModel>> GetAsync() =>
        ExecuteAsync<TestModel>(() => _client.GetAsync("history/event-guessers"));

    public Task<ApiResponse<TestBuilder>> GetBuilderAsync() =>
        ExecuteAsync<TestBuilder>(() => _client.GetAsync("history/event-guessers/builder"));

    public Task<ApiResponse<ConclusionModel>> ConcludeAsync() =>
        ExecuteAsync<ConclusionModel>(() => _client.GetAsync("history/event-guessers/conclusion"));

    public Task<ApiResponse<TestModel>> CreateAsync(CreateRequest request) =>
        ExecuteAsync<TestModel>(() => _client.PostAsync("history/event-guessers", ToJson(request)));

    public Task<ApiResponse<CheckModel>> CheckAsync(CheckRequest request) =>
        ExecuteAsync<CheckModel>(() => _client.PutAsync("history/event-guessers", ToJson(request)));
}