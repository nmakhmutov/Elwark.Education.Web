using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Quiz.Model;
using Education.Web.Client.Features.History.Clients.Quiz.Request;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Clients.Quiz;

public interface IHistoryQuizClient
{
    Task<ApiResult<EpochQuizBuilderModel>> GetTestBuilderAsync();

    Task<ApiResult<TestCreationModel>> CreateAsync(CreateQuizRequest request);

    Task<ApiResult<QuizModel>> GetAsync(string id);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel answer);

    Task<ApiResult<QuizModel>> ApplyInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id);
}
