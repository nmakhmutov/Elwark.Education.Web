using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Clients.Learner.Request;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Learner;

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
