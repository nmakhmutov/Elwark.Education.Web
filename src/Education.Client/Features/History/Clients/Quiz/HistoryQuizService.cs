using Education.Client.Clients;
using Education.Client.Features.History.Clients.Quiz.Model;
using Education.Client.Features.History.Clients.Quiz.Request;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Quiz;

internal sealed class HistoryQuizService : IHistoryQuizClient
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
