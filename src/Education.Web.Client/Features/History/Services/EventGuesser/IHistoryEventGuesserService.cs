using Education.Web.Client.Features.History.Services.EventGuesser.Model;
using Education.Web.Client.Features.History.Services.EventGuesser.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.EventGuesser;

public interface IHistoryEventGuesserService
{
    Task<ApiResult<EventGuesserBuilderModel>> GetAsync();

    Task<ApiResult<EventGuesserModel>> GetAsync(string id);

    Task<ApiResult<EventGuesserConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<EventGuesserModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<EventGuesserModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
