using Education.Client.Clients;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;

namespace Education.Client.Features.History.Clients.DateGuesser;

internal sealed class HistoryDateGuesserClient : IHistoryDateGuesserClient
{
    private readonly HistoryApiClient _api;

    public HistoryDateGuesserClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<DateGuesserBuilderModel>> GetAsync() =>
        _api.GetAsync<DateGuesserBuilderModel>("history/date-guessers");

    public Task<ApiResult<DateGuesserModel>> GetAsync(string id) =>
        _api.GetAsync<DateGuesserModel>($"history/date-guessers/{id}");

    public Task<ApiResult<DateGuesserConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<DateGuesserConclusionModel>($"history/date-guessers/{id}/conclusion");

    public Task<ApiResult<DateGuesserModel>> CreateAsync(CreateRequest request) =>
        _api.PostAsync<DateGuesserModel, CreateRequest>("history/date-guessers", request);

    public Task<ApiResult<DateGuesserModel>> CheckAsync(string testId, string questionId, CheckRequest request) =>
        _api.PostAsync<DateGuesserModel, CheckRequest>($"history/date-guessers/{testId}/questions/{questionId}",
            request);
}
