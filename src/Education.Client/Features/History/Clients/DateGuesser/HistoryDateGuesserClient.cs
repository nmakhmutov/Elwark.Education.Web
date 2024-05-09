using Education.Client.Clients;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;

namespace Education.Client.Features.History.Clients.DateGuesser;

internal sealed class HistoryDateGuesserClient : IHistoryDateGuesserClient
{
    private const string Root = "history/date-guessers";
    private readonly HistoryApiClient _api;

    public HistoryDateGuesserClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<DateGuesserBuilderModel>> GetAsync() =>
        _api.GetAsync<DateGuesserBuilderModel>(Root);

    public Task<ApiResult<DateGuesserModel>> GetAsync(string id) =>
        _api.GetAsync<DateGuesserModel>($"{Root}/{id}");

    public Task<ApiResult<DateGuesserModel>> CreateAsync(CreateRequest request) =>
        _api.PostAsync<DateGuesserModel, CreateRequest>(Root, request);

    public Task<ApiResult<DateGuesserAnswerModel>> CheckAsync(string testId, string questionId, CheckRequest request) =>
        _api.PostAsync<DateGuesserAnswerModel, CheckRequest>($"{Root}/{testId}/questions/{questionId}", request);

    public Task<ApiResult<DateGuesserModel>> UseInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<DateGuesserModel>($"{Root}/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<DateGuesserConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<DateGuesserConclusionModel>($"{Root}/{id}/conclusion");
}
