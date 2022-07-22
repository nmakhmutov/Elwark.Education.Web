using Education.Web.Services.Api;
using Education.Web.Services.History.EventGuesser.Model;
using Education.Web.Services.History.EventGuesser.Request;

namespace Education.Web.Services.History.EventGuesser;

public interface IHistoryEventGuesserService
{
    Task<ApiResult<TestBuilderModel>> GetAsync();

    Task<ApiResult<TestModel>> GetAsync(string id);

    Task<ApiResult<ConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<TestModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<TestModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
