using Education.Web.Services.Api;
using Education.Web.Services.History.User.Model;
using Education.Web.Services.History.User.Request;
using Education.Web.Services.Model;
using Education.Web.Services.Model.Statistics;
using Education.Web.Services.Model.User;

namespace Education.Web.Services.History.User;

internal sealed class HistoryUserService : IHistoryUserService
{
    private readonly ApiClient _api;

    public HistoryUserService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<HistoryUserProfileModel>> GetOverviewAsync() =>
        _api.GetAsync<HistoryUserProfileModel>("history/users/me");

    public Task<ApiResult<ProgressStatisticsModel>> GetProgressAsync() =>
        _api.GetAsync<ProgressStatisticsModel>("history/users/me/progress");

    public Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsDetailModel>("history/users/me/achievements");

    public Task<ApiResult<InventoryCompositionModel>> GetInventoryAsync() =>
        _api.GetAsync<InventoryCompositionModel>("history/users/me/inventories");

    public Task<ApiResult<DailyBonusModel>> CollectDailyBonusAsync() =>
        _api.PostAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/easy");

    public Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/hard");

    public Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/mixed");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers");

    public Task<ApiResult<PagingTokenModel<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request) =>
        _api.GetAsync<PagingTokenModel<UserTopicOverviewModel>>($"history/users/me/favorites", request);

    public Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId) =>
        _api.GetAsync<TopicStatisticsModel>($"history/users/me/topics/{topicId}");
}
