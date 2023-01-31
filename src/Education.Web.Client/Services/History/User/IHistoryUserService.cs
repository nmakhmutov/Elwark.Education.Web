using Education.Http;
using Education.Web.Client.Services.History.User.Model;
using Education.Web.Client.Services.History.User.Model.EventGuesser;
using Education.Web.Client.Services.History.User.Model.Test;
using Education.Web.Client.Services.History.User.Request;
using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Quest;
using QuestModel = Education.Web.Client.Services.History.User.Model.QuestModel;

namespace Education.Web.Client.Services.History.User;

public interface IHistoryUserService
{
    Task<ApiResult<ProfileModel>> GetProfileAsync();

    Task<ApiResult<WalletModel>> GetWalletAsync();

    Task<ApiResult<InventoriesModel>> GetInventoriesAsync();

    Task<ApiResult<QuestModel>> GetQuestAsync();

    Task<ApiResult<DailyQuestModel>> StartDailyQuestAsync();

    Task<ApiResult<DailyQuestModel>> CollectDailyQuestAsync();

    Task<ApiResult<WeeklyQuestModel>> StartWeeklyQuestAsync();

    Task<ApiResult<WeeklyQuestModel>> CollectWeeklyQuestAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<StatisticsModel>> GetStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync();

    Task<ApiResult<MoneyStatisticsModel>> GetSilverStatisticsAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();

    Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetBookmarksAsync(BookmarksRequest request);

    Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId);

    Task<ApiResult<bool>> ToggleBookmarkAsync(string articleId);

    Task<ApiResult<Unit>> LikeAsync(string articleId);

    Task<ApiResult<Unit>> DislikeAsync(string articleId);
}
