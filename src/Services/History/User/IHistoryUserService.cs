using Education.Web.Services.Api;
using Education.Web.Services.History.User.Model;
using Education.Web.Services.History.User.Request;
using Education.Web.Services.Model;
using Education.Web.Services.Model.Quest;
using Education.Web.Services.Model.Statistics;

namespace Education.Web.Services.History.User;

public interface IHistoryUserService
{
    Task<ApiResult<HistoryQuestModel>> GetQuestAsync();
    
    Task<ApiResult<DailyQuestModel>> StartDailyQuestAsync();

    Task<ApiResult<DailyQuestModel>> CollectDailyQuestAsync();
    
    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();
    
    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<InventoryCompositionModel>> GetInventoryAsync();

    Task<ApiResult<HistoryUserStatisticsModel>> GetStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync();

    Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync();
    
    Task<ApiResult<PagingTokenModel<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request);

    Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId);
}
