using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Clients.Learner.Request;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Learner;

internal sealed class HistoryLearnerService : IHistoryLearnerClient
{
    private const string Root = "history/learners/me";
    private readonly HistoryApiClient _api;

    public HistoryLearnerService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<MeOverviewModel>> GetMeAsync() =>
        _api.GetAsync<MeOverviewModel>(Root);

    public Task<ApiResult<ExaminationsStatisticsModel>> GetExaminationStatisticsAsync() =>
        _api.GetAsync<ExaminationsStatisticsModel>($"{Root}/examinations");

    public Task<ApiResult<ExaminationStatisticsModel>> GetEasyExaminationStatisticsAsync() =>
        _api.GetAsync<ExaminationStatisticsModel>($"{Root}/examinations/easy");

    public Task<ApiResult<ExaminationStatisticsModel>> GetHardExaminationStatisticsAsync() =>
        _api.GetAsync<ExaminationStatisticsModel>($"{Root}/examinations/hard");

    public Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync() =>
        _api.GetAsync<QuizzesStatisticsModel>($"{Root}/quizzes");

    public Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>($"{Root}/quizzes/easy");

    public Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>($"{Root}/quizzes/hard");

    public Task<ApiResult<QuizStatisticsModel>> GetExpertQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>($"{Root}/quizzes/Expert");

    public Task<ApiResult<DateGuessersStatisticsModel>> GetDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuessersStatisticsModel>($"{Root}/date-guessers");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetSmallDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>($"{Root}/date-guessers/small");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetMediumDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>($"{Root}/date-guessers/medium");

    public Task<ApiResult<DateGuesserStatisticsModel>> GetLargeDateGuesserStatisticsAsync() =>
        _api.GetAsync<DateGuesserStatisticsModel>($"{Root}/date-guessers/large");

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticlesAsync(ArticleActivityRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>($"{Root}/articles", request);

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(BookmarksRequest req) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>($"{Root}/articles/all/bookmarks", req);

    public Task<ApiResult<ArticleStatisticsModel>> GetArticleAsync(string articleId) =>
        _api.GetAsync<ArticleStatisticsModel>($"{Root}/articles/{articleId}");

    public Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId) =>
        _api.PostAsync<bool>($"{Root}/articles/{articleId}/bookmarks");

    public Task<ApiResult<Unit>> LikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"{Root}/articles/{articleId}/likes");

    public Task<ApiResult<Unit>> DislikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"{Root}/articles/{articleId}/dislikes");

    public Task<ApiResult<Unit>> ChangeArticleQualityAsync(string articleId, ContentQuality quality) =>
        _api.PostAsync<Unit, object>($"{Root}/articles/{articleId}/qualities", new
        {
            quality
        });

    public Task<ApiResult<PagingTokenModel<UserCourseOverviewModel>>> GetCoursesAsync(CourseActivityRequest request) =>
        _api.GetAsync<PagingTokenModel<UserCourseOverviewModel>>($"{Root}/courses", request);

    public Task<ApiResult<PagingTokenModel<UserCourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest req) =>
        _api.GetAsync<PagingTokenModel<UserCourseOverviewModel>>($"{Root}/courses/all/bookmarks", req);

    public Task<ApiResult<CourseStatisticsModel>> GetCourseAsync(string courseId) =>
        _api.GetAsync<CourseStatisticsModel>($"{Root}/courses/{courseId}");

    public Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId) =>
        _api.PostAsync<UserCourseActivityModel>($"{Root}/courses/{courseId}");

    public Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId) =>
        _api.PostAsync<bool>($"{Root}/courses/{courseId}/bookmarks");

    public Task<ApiResult<Unit>> LikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"{Root}/courses/{courseId}/likes");

    public Task<ApiResult<Unit>> DislikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"{Root}/courses/{courseId}/dislikes");
}
