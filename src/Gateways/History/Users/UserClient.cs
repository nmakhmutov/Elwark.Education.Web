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

    public Task<ApiResponse<HistoryUserProfileModel>> GetOverviewAsync() =>
        ExecuteAsync<HistoryUserProfileModel>(ct => _client.GetAsync("history/users/me", ct));

    public Task<ApiResponse<ProgressStatisticsModel>> GetProgressAsync() =>
        ExecuteAsync<ProgressStatisticsModel>(ct => _client.GetAsync("history/users/me/progress", ct));

    public Task<ApiResponse<AchievementsDetailModel>> GetAchievementsAsync() =>
        ExecuteAsync<AchievementsDetailModel>(ct => _client.GetAsync("history/users/me/achievements", ct));

    public Task<ApiResponse<InventoryCompositionModel>> GetInventoryAsync() =>
        ExecuteAsync<InventoryCompositionModel>(ct => _client.GetAsync("history/users/me/inventories", ct));

    public Task<ApiResponse<Unit>> CollectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.PostAsync("history/users/me/rewards/daily", null, ct));

    public Task<ApiResponse<Unit>> RejectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync("history/users/me/rewards/daily", ct));

    public Task<ApiResponse<TestStatisticsModel>> GetEasyTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/easy", ct));

    public Task<ApiResponse<TestStatisticsModel>> GetHardTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/hard", ct));

    public Task<ApiResponse<TestStatisticsModel>> GetMixedTestStatisticsAsync() =>
        ExecuteAsync<TestStatisticsModel>(ct => _client.GetAsync("history/users/me/tests/mixed", ct));

    public Task<ApiResponse<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        ExecuteAsync<EventGuesserStatisticsModel>(ct => _client.GetAsync("history/users/me/event-guessers", ct));

    public Task<ApiResponse<TokenPaginationResponse<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request)
    {
        var url = $"history/users/me/favorites{request.ToQueryString()}";
        return ExecuteAsync<TokenPaginationResponse<UserTopicOverviewModel>>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResponse<TopicStatisticsModel>> GetTopicsAsync(string topicId) =>
        ExecuteAsync<TopicStatisticsModel>(ct => _client.GetAsync($"history/users/me/topics/{topicId}", ct));
}
