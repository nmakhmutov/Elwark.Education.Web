using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Quiz;
using Education.Web.Client.Features.History.Services.User.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Learner;

public interface IHistoryLearnerService
{
    Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync();

    Task<ApiResult<EventGuessersStatisticsModel>> GetEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync();

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId);

    Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId);

    Task<ApiResult<Unit>> LikeArticleAsync(string articleId);

    Task<ApiResult<Unit>> DislikeArticleAsync(string articleId);

    Task<ApiResult<PagingTokenModel<UserCourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId);

    Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId);

    Task<ApiResult<Unit>> LikeCourseAsync(string courseId);

    Task<ApiResult<Unit>> DislikeCourseAsync(string courseId);
}
