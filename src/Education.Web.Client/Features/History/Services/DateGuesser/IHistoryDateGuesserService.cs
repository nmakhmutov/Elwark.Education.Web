using Education.Web.Client.Features.History.Services.DateGuesser.Model;
using Education.Web.Client.Features.History.Services.DateGuesser.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.DateGuesser;

public interface IHistoryDateGuesserService
{
    Task<ApiResult<DateGuesserBuilderModel>> GetAsync();

    Task<ApiResult<DateGuesserModel>> GetAsync(string id);

    Task<ApiResult<DateGuesserConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<DateGuesserModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<DateGuesserModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
