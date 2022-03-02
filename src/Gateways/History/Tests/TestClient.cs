using Education.Web.Gateways.History.Tests.Model;
using Education.Web.Gateways.Models.Test;

namespace Education.Web.Gateways.History.Tests;

internal sealed class TestClient : GatewayClient
{
    private readonly HttpClient _client;

    public TestClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestBuilderModel>> GetTestBuilderAsync(string? topicId) =>
        ExecuteAsync<TestBuilderModel>(ct => _client.GetAsync($"history/tests?topicId={topicId}", ct));

    public Task<ApiResponse<TestModel>> GetAsync(string id) =>
        ExecuteAsync<TestModel>(ct => _client.GetAsync($"history/tests/{id}", ct));

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerToQuestionModel answer) =>
        ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync($"history/tests/{testId}/questions/{questionId}", CreateJson(answer), ct));

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerToQuestionModel answer) =>
        ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync($"history/tests/{testId}/questions/{questionId}", CreateJson(answer), ct));

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerToQuestionModel answer) =>
        ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync($"history/tests/{testId}/questions/{questionId}", CreateJson(answer), ct));

    public Task<ApiResponse<TestConclusionModel>> GetConclusionAsync(string id) =>
        ExecuteAsync<TestConclusionModel>(ct => _client.GetAsync($"history/tests/{id}/conclusion", ct));

    public Task<ApiResponse<TestCreatedModel>> CreateEasyTestAsync(string topicId) =>
        ExecuteAsync<TestCreatedModel>(ct => _client.PostAsync($"history/tests/easy/topics/{topicId}", EmptyContent, ct));
    
    public Task<ApiResponse<TestCreatedModel>> CreateEasyTestAsync(EpochType epoch) =>
        ExecuteAsync<TestCreatedModel>(ct => _client.PostAsync($"history/tests/easy/epochs/{epoch.ToFastString()}", EmptyContent, ct));
    
    public Task<ApiResponse<TestCreatedModel>> CreateHardTestAsync(string topicId) =>
        ExecuteAsync<TestCreatedModel>(ct => _client.PostAsync($"history/tests/hard/topics/{topicId}", EmptyContent, ct));
    
    public Task<ApiResponse<TestCreatedModel>> CreateHardTestAsync(EpochType epoch) =>
        ExecuteAsync<TestCreatedModel>(ct => _client.PostAsync($"history/tests/hard/epochs/{epoch.ToFastString()}", EmptyContent, ct));

    public Task<ApiResponse<TestCreatedModel>> CreateMixedTestAsync(EpochType epoch) =>
        ExecuteAsync<TestCreatedModel>(ct => _client.PostAsync($"history/tests/mixed/epochs/{epoch.ToFastString()}", EmptyContent, ct));
}
