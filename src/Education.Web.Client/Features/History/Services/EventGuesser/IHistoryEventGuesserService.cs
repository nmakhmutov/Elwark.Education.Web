using Education.Web.Client.Features.History.Services.EventGuesser.Model;
using Education.Web.Client.Features.History.Services.EventGuesser.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.EventGuesser;

public interface IHistoryEventGuesserService
{
    Task<ApiResult<TestBuilderModel>> GetAsync();

    Task<ApiResult<TestModel>> GetAsync(string id);

    Task<ApiResult<ConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<TestModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<TestModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
