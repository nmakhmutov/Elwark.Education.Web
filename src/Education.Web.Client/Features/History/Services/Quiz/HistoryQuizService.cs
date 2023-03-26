using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz;

internal sealed class HistoryQuizService : IHistoryQuizService
{
    private readonly HistoryApiClient _api;

    public HistoryQuizService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<QuizBuilderModel>> GetTestBuilderAsync(string? articleId) =>
        _api.GetAsync<QuizBuilderModel>(articleId is { Length: > 0 }
            ? $"history/quizzes?articleId={articleId}"
            : "history/quizzes");

    public Task<ApiResult<QuizModel>> CreateAsync(CreateArticleQuizRequest request) =>
        _api.PostAsync<QuizModel, CreateArticleQuizRequest>("history/quizzes", request);

    public Task<ApiResult<QuizModel>> CreateAsync(CreateEpochQuizRequest request) =>
        _api.PostAsync<QuizModel, CreateEpochQuizRequest>("history/quizzes", request);

    public Task<ApiResult<QuizModel>> GetAsync(string id) =>
        _api.GetAsync<QuizModel>($"history/quizzes/{id}");

    public Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, MultipleAnswerModel answer) =>
        _api.PostAsync<QuizAnswerModel, MultipleAnswerModel>($"history/quizzes/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, SingleAnswerModel answer) =>
        _api.PostAsync<QuizAnswerModel, SingleAnswerModel>($"history/quizzes/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, ShortAnswerModel answer) =>
        _api.PostAsync<QuizAnswerModel, ShortAnswerModel>($"history/quizzes/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<InventoryAppliedModel>> ApplyInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<InventoryAppliedModel>($"history/quizzes/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<QuizConclusionModel>($"history/quizzes/{id}/conclusion");
}
