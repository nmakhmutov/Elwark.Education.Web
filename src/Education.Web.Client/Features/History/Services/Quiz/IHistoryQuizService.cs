using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz;

public interface IHistoryQuizService
{
    Task<ApiResult<EpochQuizBuilderModel>> GetTestBuilderAsync();

    Task<ApiResult<TestCreationModel>> CreateAsync(CreateQuizRequest request);

    Task<ApiResult<QuizModel>> GetAsync(string id);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel answer);

    Task<ApiResult<QuizModel>> ApplyInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id);
}
