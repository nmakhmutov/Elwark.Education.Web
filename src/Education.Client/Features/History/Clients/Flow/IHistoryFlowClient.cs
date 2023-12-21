using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow;

public interface IHistoryFlowClient
{
    public Task<ApiResult<FlowModel>> GetAsync();

    public Task<ApiResult<FlowModel>> StartAsync();

    public Task<ApiResult<FlowAnswerModel>> CheckAsync(string questionId, UserAnswerModel answer);

    public Task<ApiResult<Unit>> CollectBankAsync();
}
