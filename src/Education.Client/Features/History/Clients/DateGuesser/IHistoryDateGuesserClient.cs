using Education.Client.Clients;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;

namespace Education.Client.Features.History.Clients.DateGuesser;

public interface IHistoryDateGuesserClient
{
    Task<ApiResult<DateGuesserBuilderModel>> GetAsync();

    Task<ApiResult<DateGuesserModel>> GetAsync(string id);

    Task<ApiResult<DateGuesserModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<DateGuesserAnswerModel>> CheckAsync(string testId, string questionId, CheckRequest request);

    Task<ApiResult<DateGuesserModel>> UseInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<DateGuesserConclusionModel>> GetConclusionAsync(string id);
}
