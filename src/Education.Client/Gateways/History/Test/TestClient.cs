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
        ExecuteAsync<TestBuilder>(() => _client.GetAsync("history/tests/builder"));
        
    public Task<ApiResponse<TestModel>> GetAsync(string id) =>
        ExecuteAsync<TestModel>(() => _client.GetAsync($"history/tests/{id}"));

    public Task<ApiResponse<ManyAnswersResult>> CheckAsync(string testId, string questionId, ManyAnswer answer) =>
        ExecuteAsync<ManyAnswersResult>(() =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

    public Task<ApiResponse<OneAnswerResult>> CheckAsync(string testId, string questionId, OneAnswer answer) =>
        ExecuteAsync<OneAnswerResult>(() =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

    public Task<ApiResponse<TextAnswerResult>> CheckAsync(string testId, string questionId, TextAnswer answer) =>
        ExecuteAsync<TextAnswerResult>(() =>
            _client.PostAsync($"history/tests/{testId}/questions/{questionId}", ToJson(answer)));

    public Task<ApiResponse<TestConclusion>> GetConclusionAsync(string id) =>
        ExecuteAsync<TestConclusion>(() => _client.GetAsync($"history/tests/{id}/conclusion"));
        
    public Task<ApiResponse<TestCreatedResult>> CreateRandomEasyTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(() => _client.PostAsync("history/tests/easy", ToJson(request)));
        
    public Task<ApiResponse<TestCreatedResult>> CreateRandomHardTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(() => _client.PostAsync("history/tests/hard", ToJson(request)));
        
    public Task<ApiResponse<TestCreatedResult>> CreateRandomMixedTestAsync(CreateTestRequest request) =>
        ExecuteAsync<TestCreatedResult>(() => _client.PostAsync("history/tests/mixed", ToJson(request)));
}
    
public sealed record CreateTestRequest(EpochType Epoch);