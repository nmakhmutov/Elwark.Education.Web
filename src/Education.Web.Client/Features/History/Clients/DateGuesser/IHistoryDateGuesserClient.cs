using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.DateGuesser.Model;
using Education.Web.Client.Features.History.Clients.DateGuesser.Request;

namespace Education.Web.Client.Features.History.Clients.DateGuesser;

public interface IHistoryDateGuesserClient
{
    Task<ApiResult<DateGuesserBuilderModel>> GetAsync();

    Task<ApiResult<DateGuesserModel>> GetAsync(string id);

    Task<ApiResult<DateGuesserConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<DateGuesserModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<DateGuesserModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
