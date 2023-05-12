using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Quiz;
using Education.Web.Client.Features.History.Services.User.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User;

public interface IHistoryUserService
{
    Task<ApiResult<ProfileModel>> GetProfileAsync();

    Task<ApiResult<InventoryModel>> GetInventoryAsync();
    
    Task<ApiResult<BackpackModel>> GetBackpackAsync();

    Task<ApiResult<IReadOnlyCollection<WalletModel>>> GetWalletAsync();

    Task<ApiResult<UserQuestModel>> GetQuestAsync();

    Task<ApiResult<QuestsModel>> StartDailyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectDailyQuestAsync();

    Task<ApiResult<QuestsModel>> StartWeeklyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectWeeklyQuestAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync();
    
    Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync();

    Task<ApiResult<EventGuessersStatisticsModel>> GetEventGuesserStatisticsAsync();
    
    Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId);

    Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId);

    Task<ApiResult<Unit>> LikeArticleAsync(string articleId);

    Task<ApiResult<Unit>> DislikeArticleAsync(string articleId);

    Task<ApiResult<PagingTokenModel<CourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId);

    Task<ApiResult<Unit>> LikeCourseAsync(string courseId);

    Task<ApiResult<Unit>> DislikeCourseAsync(string courseId);
}
