using Education.Web.Client.Features.History.Services.Quiz.Model;
using Education.Web.Client.Features.History.Services.Quiz.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quiz;

namespace Education.Web.Client.Features.History.Services.Quiz;

internal sealed class HistoryQuizService : IHistoryQuizService
{
    private const string Root = "history/quizzes";
    private readonly HistoryApiClient _api;

    public HistoryQuizService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<QuizBuilderModel>> GetTestBuilderAsync(string? articleId) =>
        _api.GetAsync<QuizBuilderModel>(string.IsNullOrEmpty(articleId) ? Root : $"{Root}?articleId={articleId}");

    public Task<ApiResult<QuizModel>> CreateAsync(CreateArticleQuizRequest request) =>
        _api.PostAsync<QuizModel, CreateArticleQuizRequest>(Root, request);

    public Task<ApiResult<QuizModel>> CreateAsync(CreateEpochQuizRequest request) =>
        _api.PostAsync<QuizModel, CreateEpochQuizRequest>(Root, request);

    public Task<ApiResult<QuizModel>> GetAsync(string id) =>
        _api.GetAsync<QuizModel>($"{Root}/{id}");

    public Task<ApiResult<QuizAnswerModel>> CheckAsync(string testId, string questionId, AnswerToQuestionModel answer) =>
        _api.PostAsync<QuizAnswerModel, AnswerToQuestionModel>($"{Root}/{testId}/questions/{questionId}", answer);

    public Task<ApiResult<QuizModel>> ApplyInventoryAsync(string testId, uint inventoryId) =>
        _api.PostAsync<QuizModel>($"{Root}/{testId}/inventories/{inventoryId}");

    public Task<ApiResult<QuizConclusionModel>> GetConclusionAsync(string id) =>
        _api.GetAsync<QuizConclusionModel>($"{Root}/{id}/conclusion");
}
