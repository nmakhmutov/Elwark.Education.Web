using Education.Web.Client.Features.History.Services.EventGuesser.Model;
using Education.Web.Client.Features.History.Services.EventGuesser.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.EventGuesser;

internal sealed class HistoryEventGuesserService : IHistoryEventGuesserService
{
    private readonly HistoryApiClient _api;

    public HistoryEventGuesserService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<EventGuesserBuilderModel>> GetAsync() =>
        _api.GetAsync<EventGuesserBuilderModel>("history/event-guessers");

    public Task<ApiResult<EventGuesserModel>> GetAsync(string id) =>
        _api.GetAsync<EventGuesserModel>($"history/event-guessers/{id}");

    public Task<ApiResult<EventGuesserConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<EventGuesserConclusionModel>($"history/event-guessers/{id}/conclusion");

    public Task<ApiResult<EventGuesserModel>> CreateAsync(CreateRequest request) =>
        _api.PostAsync<EventGuesserModel, CreateRequest>("history/event-guessers", request);

    public Task<ApiResult<EventGuesserModel>> CheckAsync(string testId, string questionId, CheckRequest request) =>
        _api.PostAsync<EventGuesserModel, CheckRequest>($"history/event-guessers/{testId}/questions/{questionId}", request);
}
