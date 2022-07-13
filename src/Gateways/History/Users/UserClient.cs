using Education.Web.Gateways.History.Users.Model;
using Education.Web.Gateways.History.Users.Request;
using Education.Web.Gateways.Models;
using Education.Web.Gateways.Models.Statistics;

namespace Education.Web.Gateways.History.Users;

internal sealed class UserClient : GatewayClient
{
    private readonly HttpClient _client;

    public UserClient(HttpClient client) =>
        _client = client;

    public Task<ApiResult<HistoryUserProfileModel>> GetOverviewAsync() =>
        ExecuteAsync<HistoryUserProfileModel>(ct => _client.GetAsync("history/users/me", ct));

    public Task<ApiResult<ProgressStatisticsModel>> GetProgressAsync() =>
        ExecuteAsync<ProgressStatisticsModel>(ct => _client.GetAsync("history/users/me/progress", ct));

    public Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync() =>
        ExecuteAsync<AchievementsDetailModel>(ct => _client.GetAsync("history/users/me/achievements", ct));

    public Task<ApiResult<InventoryCompositionModel>> GetInventoryAsync() =>
        ExecuteAsync<InventoryCompositionModel>(ct => _client.GetAsync("history/users/me/inventories", ct));

    public Task<ApiResult<Unit>> CollectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.PostAsync("history/users/me/rewards/daily", null, ct));

    public Task<ApiResult<Unit>> RejectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync("history/users/me/rewards/daily", ct));

    public Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/easy", ct));

    public Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/hard", ct));

    public Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/mixed", ct));

    public Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        ExecuteAsync<EventGuesserStatisticsModel>(ct => _client.GetAsync("history/users/me/event-guessers", ct));

    public Task<ApiResult<TokenPaginationResponse<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request)
    {
        var url = $"history/users/me/favorites{request.ToQueryString()}";
        return ExecuteAsync<TokenPaginationResponse<UserTopicOverviewModel>>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId) =>
        ExecuteAsync<TopicStatisticsModel>(ct => _client.GetAsync($"history/users/me/topics/{topicId}", ct));
}
