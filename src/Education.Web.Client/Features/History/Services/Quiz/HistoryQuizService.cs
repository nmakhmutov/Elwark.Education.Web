using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Quiz;

internal sealed class HistoryQuizService : IHistoryQuizService
{
    private const string Root = "history/quizzes";
    private readonly HistoryApiClient _api;

    public HistoryQuizService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<EpochQuizBuilderModel>> GetTestBuilderAsync() =>
        _api.GetAsync<EpochQuizBuilderModel>(Root);

    public Task<ApiResult<TestCreationModel>> CreateAsync(CreateQuizRequest request) =>
        _api.PostAsync<TestCreationModel, CreateQuizRequest>(Root, request);

    public Task<ApiResult<QuizModel>> GetAsync(string id) =>
        _api.GetAsync<QuizModel>($"{Root}/{id}");

    public Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, UserAnswerModel answer) =>
        _api.PostAsync<QuizAnswerModel, UserAnswerModel>($"{Root}/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<QuizModel>> ApplyInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<QuizModel>($"{Root}/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<QuizConclusionModel>($"{Root}/{id}/conclusion");
}
