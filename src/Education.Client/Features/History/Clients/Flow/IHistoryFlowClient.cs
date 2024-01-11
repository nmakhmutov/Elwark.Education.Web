using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Flow;

public interface IHistoryFlowClient
{
    Task<ApiResult<FlowModel>> GetAsync();

    Task<ApiResult<FlowModel>> StartAsync();

    Task<ApiResult<FlowAnswerModel>> CheckAsync(string questionId, UserAnswerModel answer);

    Task<ApiResult<Unit>> CollectBankAsync();
}
