using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Test.Model;
using Education.Web.Client.Services.History.Test.Request;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test;

public interface IHistoryTestService
{
    Task<ApiResult<TestBuilderModel>> GetTestBuilderAsync(string? articleId);

    Task<ApiResult<TestModel>> CreateAsync(CreateArticleTestRequest request);

    Task<ApiResult<TestModel>> CreateAsync(CreateEpochTestRequest request);

    Task<ApiResult<TestModel>> GetAsync(string id);

    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer);

    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer);

    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer);

    Task<ApiResult<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<TestConclusion>> GetConclusionAsync(string id);
}
