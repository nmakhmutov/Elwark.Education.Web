using Education.Web.Services.Api;
using Education.Web.Services.History.User.Model;
using Education.Web.Services.History.User.Request;
using Education.Web.Services.Model;
using Education.Web.Services.Model.Quest;
using Education.Web.Services.Model.Statistics;

namespace Education.Web.Services.History.User;

internal sealed class HistoryUserService : IHistoryUserService
{
    private readonly ApiClient _api;

    public HistoryUserService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsDetailModel>("history/users/me/achievements");

    public Task<ApiResult<InventoryCompositionModel>> GetInventoryAsync() =>
        _api.GetAsync<InventoryCompositionModel>("history/users/me/inventories");

    public Task<ApiResult<HistoryQuestModel>> GetQuestAsync() =>
        _api.GetAsync<HistoryQuestModel>("history/users/me/quests");

    public Task<ApiResult<DailyQuestModel>> StartDailyQuestAsync() =>
        _api.PostAsync<DailyQuestModel>("history/users/me/quests/daily");

    public Task<ApiResult<DailyQuestModel>> CollectDailyQuestAsync() =>
        _api.PutAsync<DailyQuestModel>("history/users/me/quests/daily");
    
    public Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync() =>
        _api.PutAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<HistoryUserStatisticsModel>> GetStatisticsAsync() =>
        _api.GetAsync<HistoryUserStatisticsModel>("history/users/me/statistics");

    public Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/easy");

    public Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/hard");

    public Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync() =>
        _api.GetAsync<TestStatisticsModel>("history/users/me/tests/mixed");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers");

    public Task<ApiResult<PagingTokenModel<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request) =>
        _api.GetAsync<PagingTokenModel<UserTopicOverviewModel>>("history/users/me/favorites", request);

    public Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId) =>
        _api.GetAsync<TopicStatisticsModel>($"history/users/me/topics/{topicId}");
}
