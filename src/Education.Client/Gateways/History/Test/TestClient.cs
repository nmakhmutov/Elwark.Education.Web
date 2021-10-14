using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Test;

internal sealed class TestClient : GatewayClient
{
    private readonly HttpClient _client;

    public TestClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestBuilder>> GetTestBuilderAsync() =>
        ExecuteAsync<TestBuilder>(ct => _client.GetAsync("history/tests/builder", ct));

    public Task<ApiResponse<TestModel>> GetAsync(string id) =>
        ExecuteAsync<TestModel>(ct => _client.GetAsync($"history/tests/{id}", ct));

    public Task<ApiResponse<ManyAnswersResult>> CheckAsync(string testId, string questionId, ManyAnswer answer) =>
        ExecuteAsync<ManyAnswersResult>(ct =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer), ct));

    public Task<ApiResponse<OneAnswerResult>> CheckAsync(string testId, string questionId, OneAnswer answer) =>
        ExecuteAsync<OneAnswerResult>(ct =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer), ct));

    public Task<ApiResponse<TextAnswerResult>> CheckAsync(string testId, string questionId, TextAnswer answer) =>
        ExecuteAsync<TextAnswerResult>(ct =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer), ct));

    public Task<ApiResponse<TestConclusion>> GetConclusionAsync(string id) =>
        ExecuteAsync<TestConclusion>(ct => _client.GetAsync($"history/tests/{id}/conclusion", ct));

    public Task<ApiResponse<TestCreatedResult>> CreateRandomEasyTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(ct => _client.PostAsync("history/tests/easy", ToJson(request), ct));

    public Task<ApiResponse<TestCreatedResult>> CreateRandomHardTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(ct => _client.PostAsync("history/tests/hard", ToJson(request), ct));

    public Task<ApiResponse<TestCreatedResult>> CreateRandomMixedTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(ct => _client.PostAsync("history/tests/mixed", ToJson(request), ct));
}

public sealed record CreateTestRequest(EpochType Epoch);
