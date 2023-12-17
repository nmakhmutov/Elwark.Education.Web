using Education.Web.Client.Features.History.Services.Learner.Model;
using Education.Web.Client.Features.History.Services.Learner.Model.DateGuesser;
using Education.Web.Client.Features.History.Services.Learner.Model.Quiz;
using Education.Web.Client.Features.History.Services.Learner.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Learner;

internal sealed class HistoryLearnerService : IHistoryLearnerService
{
    private readonly HistoryApiClient _api;

    public HistoryLearnerService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync() =>
        _api.GetAsync<QuizzesStatisticsModel>("history/learners/me/quizzes");

    public Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>("history/learners/me/quizzes/easy");

    public Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>("history/learners/me/quizzes/hard");

    public Task<ApiResult<DateGuessersStatisticsModel>> GetDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuessersStatisticsModel>("history/learners/me/date-guessers");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetSmallDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>("history/learners/me/date-guessers/small");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetMediumDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>("history/learners/me/date-guessers/medium");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetLargeDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>("history/learners/me/date-guessers/large");

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleHistoryAsync(HistoryRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>("history/learners/me/articles", request);

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(
        BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>("history/learners/me/articles/bookmarks", request);

    public Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId) =>
        _api.GetAsync<ArticleStatisticsModel>($"history/learners/me/articles/{articleId}");

    public Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId) =>
        _api.PostAsync<bool>($"history/learners/me/articles/{articleId}/bookmarks");

    public Task<ApiResult<Unit>> LikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/learners/me/articles/{articleId}/likes");

    public Task<ApiResult<Unit>> DislikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/learners/me/articles/{articleId}/dislikes");

    public Task<ApiResult<PagingTokenModel<UserCourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<UserCourseOverviewModel>>("history/learners/me/courses/bookmarks", request);

    public Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId) =>
        _api.PostAsync<UserCourseActivityModel>($"/history/learners/me/courses/{courseId}");

    public Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId) =>
        _api.PostAsync<bool>($"history/learners/me/courses/{courseId}/bookmarks");

    public Task<ApiResult<Unit>> LikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/learners/me/courses/{courseId}/likes");

    public Task<ApiResult<Unit>> DislikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/learners/me/courses/{courseId}/dislikes");
}
