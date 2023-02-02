using Education.Web.Client.Features.History.Services.Test.Model;
using Education.Web.Client.Features.History.Services.Test.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Test;

internal sealed class HistoryTestService : IHistoryTestService
{
    private readonly HistoryApiClient _api;

    public HistoryTestService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<TestBuilderModel>> GetTestBuilderAsync(string? articleId) =>
        _api.GetAsync<TestBuilderModel>(articleId is { Length: > 0 }
            ? $"history/tests?articleId={articleId}"
            : "history/tests");

    public Task<ApiResult<TestModel>> CreateAsync(CreateArticleTestRequest request) =>
        _api.PostAsync<TestModel, CreateArticleTestRequest>("history/tests", request);

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
