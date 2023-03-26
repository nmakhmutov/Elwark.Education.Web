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

    Task<ApiResult<BackpackModel>> GetBackpackAsync();

    Task<ApiResult<WalletModel>> GetWalletAsync();

    Task<ApiResult<UserQuestModel>> GetQuestAsync();

    Task<ApiResult<QuestsModel>> StartDailyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectDailyQuestAsync();

    Task<ApiResult<QuestsModel>> StartWeeklyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectWeeklyQuestAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<StatisticsModel>> GetStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync();

    Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync();

    Task<ApiResult<AccountingModel>> GetSilverAccountingAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId);

    Task<ApiResult<bool>> ToggleBookmarkAsync(string articleId);

    Task<ApiResult<Unit>> LikeAsync(string articleId);

    Task<ApiResult<Unit>> DislikeAsync(string articleId);
}
