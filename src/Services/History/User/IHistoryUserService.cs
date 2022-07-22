using Education.Web.Services.Api;
using Education.Web.Services.History.User.Model;
using Education.Web.Services.History.User.Request;
using Education.Web.Services.Model;
using Education.Web.Services.Model.Statistics;

namespace Education.Web.Services.History.User;

public interface IHistoryUserService
{
    Task<ApiResult<HistoryUserProfileModel>> GetOverviewAsync();

    Task<ApiResult<ProgressStatisticsModel>> GetProgressAsync();

    Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync();

    Task<ApiResult<InventoryCompositionModel>> GetInventoryAsync();

    Task<ApiResult<Unit>> CollectDailyBonusAsync();

    Task<ApiResult<Unit>> RejectDailyBonusAsync();

    Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync();

    Task<ApiResult<TokenPaginationResponse<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request);

    Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId);
}
