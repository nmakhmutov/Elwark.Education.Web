using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.EventGuesser.Model;
using Education.Web.Client.Services.History.EventGuesser.Request;

namespace Education.Web.Client.Services.History.EventGuesser;

public interface IHistoryEventGuesserService
{
    Task<ApiResult<TestBuilderModel>> GetAsync();

    Task<ApiResult<TestModel>> GetAsync(string id);

    Task<ApiResult<ConclusionModel>> GetConclusionAsync(string id);

    Task<ApiResult<TestModel>> CreateAsync(CreateRequest request);

    Task<ApiResult<TestModel>> CheckAsync(string testId, string questionId, CheckRequest request);
}
