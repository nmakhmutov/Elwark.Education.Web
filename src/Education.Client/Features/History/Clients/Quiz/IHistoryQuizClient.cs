using Education.Client.Clients;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Features.History.Clients.Quiz.Request;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz;

public interface IHistoryQuizClient
{
    Task<ApiResult<EpochQuizBuilderModel>> GetTestBuilderAsync();

    Task<ApiResult<TestCreationModel>> CreateAsync(CreateQuizRequest request);

    Task<ApiResult<QuizModel>> GetAsync(string id);

    Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel answer);

    Task<ApiResult<QuizModel>> UseInventoryAsync(string testId, uint inventoryId);

    Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id);
}
