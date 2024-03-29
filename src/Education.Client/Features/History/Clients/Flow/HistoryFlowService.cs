using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow;

internal sealed class HistoryFlowService : IHistoryFlowClient
{
    private readonly HistoryApiClient _api;

    public HistoryFlowService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<FlowModel>> GetAsync() =>
        _api.GetAsync<FlowModel>("history/flows/me");

    public Task<ApiResult<FlowModel>> StartAsync() =>
        _api.PostAsync<FlowModel>("history/flows/me");

    public Task<ApiResult<FlowAnswerModel>> CheckAsync(string questionId, UserAnswerModel answer) =>
        _api.PostAsync<FlowAnswerModel, UserAnswerModel>($"history/flows/me/questions/{questionId}", answer);

    public Task<ApiResult<Unit>> CollectBankAsync() =>
        _api.PostAsync<Unit>("history/flows/me/bank");
}
