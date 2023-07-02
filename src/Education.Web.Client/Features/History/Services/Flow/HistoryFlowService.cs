using Education.Web.Client.Features.History.Services.Flow.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Flow;

internal sealed class HistoryFlowService : IHistoryFlowService
{
    private readonly HistoryApiClient _api;

    public HistoryFlowService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<FlowModel>> StartAsync() =>
        _api.PostAsync<FlowModel>("history/flows/me");

    public Task<ApiResult<FlowModel>> GetAsync() =>
        _api.GetAsync<FlowModel>("history/flows/me");

    public Task<ApiResult<FlowModel>> CheckAsync(string questionId, AnswerToQuestionModel answer) =>
        _api.PostAsync<FlowModel, AnswerToQuestionModel>($"history/flows/me/questions/{questionId}", answer);

    public Task<ApiResult<Unit>> CollectBankAsync() =>
        _api.GetAsync<Unit>("history/flows/me/bank");
}
