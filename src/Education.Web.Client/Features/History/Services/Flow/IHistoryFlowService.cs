using Education.Web.Client.Features.History.Services.Flow.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Flow;

public interface IHistoryFlowService
{
    public Task<ApiResult<FlowModel>> StartAsync();

    public Task<ApiResult<FlowModel>> GetAsync();

    public Task<ApiResult<FlowModel>> CheckAsync(string questionId, AnswerToQuestionModel answer);

    public Task<ApiResult<Unit>> CollectBankAsync();
}
