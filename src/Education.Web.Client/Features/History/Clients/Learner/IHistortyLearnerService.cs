using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Learner.Model;
using Education.Web.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Web.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Web.Client.Features.History.Clients.Learner.Request;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.Learner;

public interface IHistoryLearnerClient
{
    Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync();

    Task<ApiResult<DateGuessersStatisticsModel>> GetDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetSmallDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetMediumDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetLargeDateGuesserStatisticsAsync();

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleHistoryAsync(HistoryRequest request);

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
