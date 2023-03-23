using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz;

public interface IHistoryQuizService
{
    Task<ApiResult<QuizBuilderModel>> GetTestBuilderAsync(string? articleId);

    Task<ApiResult<QuizModel>> CreateAsync(CreateArticleTestRequest request);

    Task<ApiResult<QuizModel>> CreateAsync(CreateEpochTestRequest request);

    Task<ApiResult<QuizModel>> GetAsync(string id);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer);

    Task<ApiResult<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id);
}
