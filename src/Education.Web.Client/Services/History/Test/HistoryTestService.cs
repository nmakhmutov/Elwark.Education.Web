using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Test.Model;
using Education.Web.Client.Services.History.Test.Request;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test;

internal sealed class HistoryTestService : IHistoryTestService
{
    private readonly ApiClient _api;

    public HistoryTestService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<TestBuilderModel>> GetTestBuilderAsync(string? topicId) =>
        _api.GetAsync<TestBuilderModel>(topicId is { Length: > 0 }
            ? $"history/tests?topicId={topicId}"
            : "history/tests");

    public Task<ApiResult<TestModel>> CreateAsync(CreateTopicTestRequest request) =>
        _api.PostAsync<TestModel, CreateTopicTestRequest>("history/tests", request);

    public Task<ApiResult<TestModel>> CreateAsync(CreateEpochTestRequest request) =>
        _api.PostAsync<TestModel, CreateEpochTestRequest>("history/tests", request);

    public Task<ApiResult<TestModel>> GetAsync(string id) =>
        _api.GetAsync<TestModel>($"history/tests/{id}");

    public Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer) =>
        _api.PostAsync<TestAnswerModel, MultipleAnswerModel>($"history/tests/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer) =>
        _api.PostAsync<TestAnswerModel, SingleAnswerModel>($"history/tests/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer) =>
        _api.PostAsync<TestAnswerModel, ShortAnswerModel>($"history/tests/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<InventoryAppliedModel>($"history/tests/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<TestConclusion>> GetConclusionAsync(string id) =>
        _api.GetAsync<TestConclusion>($"history/tests/{id}/conclusion");
}
