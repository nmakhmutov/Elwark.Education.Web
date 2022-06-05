using Education.Web.Gateways.History.Tests.Model;
using Education.Web.Gateways.History.Tests.Requests;
using Education.Web.Gateways.Models.Test;

namespace Education.Web.Gateways.History.Tests;

internal sealed class TestClient : GatewayClient
{
    private const string Route = "history/tests";
    private readonly HttpClient _client;

    public TestClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<TestBuilderModel>> GetTestBuilderAsync(string? topicId)
    {
        var url = topicId is { Length: > 0 } ? $"{Route}?topicId={topicId}" : Route;
        return ExecuteAsync<TestBuilderModel>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResponse<TestModel>> CreateAsync(CreateTopicTestRequest request) =>
        ExecuteAsync<TestModel>(ct => _client.PostAsync(Route, CreateJson(request), ct));

    public Task<ApiResponse<TestModel>> CreateAsync(CreateEpochTestRequest request) =>
        ExecuteAsync<TestModel>(ct => _client.PostAsync(Route, CreateJson(request), ct));
    
    public Task<ApiResponse<TestModel>> GetAsync(string id) =>
        ExecuteAsync<TestModel>(ct => _client.GetAsync($"{Route}/{id}", ct));

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer)
    {
        var url = $"{Route}/{testId}/questions/{questionId}";
        return ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync(url, CreateJson(answer), ct));
    }

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer)
    {
        var url = $"{Route}/{testId}/questions/{questionId}";
        return ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync(url, CreateJson(answer), ct));
    }

    public Task<ApiResponse<TestAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer)
    {
        var url = $"{Route}/{testId}/questions/{questionId}";
        return ExecuteAsync<TestAnswerModel>(ct => _client.PostAsync(url, CreateJson(answer), ct));
    }

    public Task<ApiResponse<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId)
    {
        var url = $"{Route}/{testId}/inventories/{inventoryId}";
        return ExecuteAsync<InventoryAppliedModel>(ct => _client.PostAsync(url, null, ct));
    }

    public Task<ApiResponse<TestConclusionModel>> GetConclusionAsync(string id)
    {
        var url = $"{Route}/{id}/conclusion";
        return ExecuteAsync<TestConclusionModel>(ct => _client.GetAsync(url, ct));
    }
}
