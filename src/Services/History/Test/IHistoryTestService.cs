using Education.Web.Services.Api;
using Education.Web.Services.History.Test.Model;
using Education.Web.Services.History.Test.Request;
using Education.Web.Services.Model.Test;

namespace Education.Web.Services.History.Test;

public interface IHistoryTestService
{
    Task<ApiResult<TestBuilderModel>> GetTestBuilderAsync(string? topicId);
    
    Task<ApiResult<TestModel>> CreateAsync(CreateTopicTestRequest request);
    
    Task<ApiResult<TestModel>> CreateAsync(CreateEpochTestRequest request);
    
    Task<ApiResult<TestModel>> GetAsync(string id);
    
    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer);
    
    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer);
    
    Task<ApiResult<TestAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer);
    
    Task<ApiResult<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId);
    
    Task<ApiResult<TestConclusionModel>> GetConclusionAsync(string id);
}
