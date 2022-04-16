using Education.Web.Gateways.History.EventGuesser.Model;
using Education.Web.Gateways.History.EventGuesser.Request;

namespace Education.Web.Gateways.History.EventGuesser;

internal sealed class EventGuesserClient : GatewayClient
{
    private readonly HttpClient _client;
    private const string Route = "history/event-guessers";

    public EventGuesserClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestBuilderModel>> GetAsync() =>
        ExecuteAsync<TestBuilderModel>(ct => _client.GetAsync(Route, ct));

    public Task<ApiResponse<TestModel>> GetAsync(string id) =>
        ExecuteAsync<TestModel>(ct => _client.GetAsync($"{Route}/{id}", ct));

    public Task<ApiResponse<ConclusionModel>> GetConclusionAsync(string id) =>
        ExecuteAsync<ConclusionModel>(ct => _client.GetAsync($"{Route}/{id}/conclusion", ct));

    public Task<ApiResponse<TestModel>> CreateAsync(CreateRequest request) =>
        ExecuteAsync<TestModel>(ct => _client.PostAsync(Route, CreateJson(request), ct));

    public Task<ApiResponse<TestModel>> CheckAsync(string testId, string questionId, CheckRequest request)
    {
        var url = $"{Route}/{testId}/questions/{questionId}";
        return ExecuteAsync<TestModel>(ct => _client.PostAsync(url, CreateJson(request), ct));
    }
}
