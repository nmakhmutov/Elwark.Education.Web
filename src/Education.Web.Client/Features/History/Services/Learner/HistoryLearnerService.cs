using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Quiz;
using Education.Web.Client.Features.History.Services.User.Request;
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

    public Task<ApiResult<EventGuessersStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuessersStatisticsModel>("history/learners/me/event-guessers");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/learners/me/event-guessers/small");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/learners/me/event-guessers/medium");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/learners/me/event-guessers/large");

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>("history/users/me/articles/bookmarks", request);
    
    public Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId) =>
        _api.GetAsync<ArticleStatisticsModel>($"history/learners/me/articles/{articleId}");

    public Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId) =>
        _api.PostAsync<bool>($"history/learners/me/articles/{articleId}/bookmarks");

    public Task<ApiResult<Unit>> LikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/learners/me/articles/{articleId}/likes");

    public Task<ApiResult<Unit>> DislikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/learners/me/articles/{articleId}/dislikes");

    public Task<ApiResult<PagingTokenModel<CourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<CourseOverviewModel>>("history/users/me/courses/bookmarks", request);
    
    public Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId) =>
        _api.PostAsync<UserCourseActivityModel>($"/history/learners/me/courses/{courseId}");
    
    public Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId) =>
        _api.PostAsync<bool>($"history/learners/me/courses/{courseId}/bookmarks");

    public Task<ApiResult<Unit>> LikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/learners/me/courses/{courseId}/likes");

    public Task<ApiResult<Unit>> DislikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/learners/me/courses/{courseId}/dislikes");
}
