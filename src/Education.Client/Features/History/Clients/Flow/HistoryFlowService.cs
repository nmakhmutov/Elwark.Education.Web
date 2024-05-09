using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow;

internal sealed class HistoryFlowService : IHistoryFlowClient
{
    private const string Root = "history/flows/me";
    private readonly HistoryApiClient _api;

    public HistoryFlowService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<FlowModel>> GetAsync() =>
        _api.GetAsync<FlowModel>(Root);

    public Task<ApiResult<FlowModel>> StartAsync() =>
        _api.PostAsync<FlowModel>(Root);

    public Task<ApiResult<FlowAnswerModel>> CheckAsync(string questionId, UserAnswerModel answer) =>
        _api.PostAsync<FlowAnswerModel, UserAnswerModel>($"{Root}/questions/{questionId}", answer);

    public Task<ApiResult<Unit>> CollectBankAsync() =>
        _api.PostAsync<Unit>($"{Root}/bank");
}
