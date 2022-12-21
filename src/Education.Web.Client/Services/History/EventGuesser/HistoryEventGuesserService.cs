using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.EventGuesser.Model;
using Education.Web.Client.Services.History.EventGuesser.Request;

namespace Education.Web.Client.Services.History.EventGuesser;

internal sealed class HistoryEventGuesserService : IHistoryEventGuesserService
{
    private readonly ApiClient _api;

    public HistoryEventGuesserService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<TestBuilderModel>> GetAsync() =>
        _api.GetAsync<TestBuilderModel>("history/event-guessers");

    public Task<ApiResult<TestModel>> GetAsync(string id) =>
        _api.GetAsync<TestModel>($"history/event-guessers/{id}");

    public Task<ApiResult<ConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<ConclusionModel>($"history/event-guessers/{id}/conclusion");

    public Task<ApiResult<TestModel>> CreateAsync(CreateRequest request) =>
        _api.PostAsync<TestModel, CreateRequest>("history/event-guessers", request);

    public Task<ApiResult<TestModel>> CheckAsync(string testId, string questionId, CheckRequest request) =>
        _api.PostAsync<TestModel,CheckRequest>($"history/event-guessers/{testId}/questions/{questionId}", request);
}
