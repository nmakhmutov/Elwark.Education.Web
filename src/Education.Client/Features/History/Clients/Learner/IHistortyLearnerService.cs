using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Features.History.Clients.Learner.Model.DateGuesser;
using Education.Client.Features.History.Clients.Learner.Model.Examination;
using Education.Client.Features.History.Clients.Learner.Model.Quiz;
using Education.Client.Features.History.Clients.Learner.Request;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Learner;

public interface IHistoryLearnerClient
{
    Task<ApiResult<MeOverviewModel>> GetMeAsync();

    Task<ApiResult<ExaminationsStatisticsModel>> GetExaminationStatisticsAsync();

    Task<ApiResult<ExaminationStatisticsModel>> GetEasyExaminationStatisticsAsync();

    Task<ApiResult<ExaminationStatisticsModel>> GetHardExaminationStatisticsAsync();

    Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync();

    Task<ApiResult<DateGuessersStatisticsModel>> GetDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetSmallDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetMediumDateGuesserStatisticsAsync();

    Task<ApiResult<DateGuesserStatisticsModel>> GetLargeDateGuesserStatisticsAsync();

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticlesAsync(HistoryRequest request);

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(BookmarksRequest req);

    Task<ApiResult<ArticleStatisticsModel>> GetArticleAsync(string articleId);

    Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId);

    Task<ApiResult<Unit>> LikeArticleAsync(string articleId);

    Task<ApiResult<Unit>> DislikeArticleAsync(string articleId);

    Task<ApiResult<PagingTokenModel<UserCourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest req);

    Task<ApiResult<CourseStatisticsModel>> GetCourseAsync(string courseId);

    Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId);

    Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId);

    Task<ApiResult<Unit>> LikeCourseAsync(string courseId);

    Task<ApiResult<Unit>> DislikeCourseAsync(string courseId);
}
