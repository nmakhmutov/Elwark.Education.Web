using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.Statistics;

namespace Education.Client.Gateways.History.User;

internal sealed class UserClient : GatewayClient
{
    private readonly HttpClient _client;

    public UserClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<HistoryUserProfile>> GetOverviewAsync() =>
        ExecuteAsync<HistoryUserProfile>(ct => _client.GetAsync("history/users/me", ct));

    public Task<ApiResponse<ActivityStatistics>> GetActivitiesAsync() =>
        ExecuteAsync<ActivityStatistics>(ct => _client.GetAsync("history/users/me/activities", ct));

    public Task<ApiResponse<AchievementStatistics[]>> GetAchievementsAsync() =>
        ExecuteAsync<AchievementStatistics[]>(ct => _client.GetAsync("history/users/me/achievements", ct));

    public Task<ApiResponse<Unit>> CollectDailyReward() =>
        ExecuteAsync<Unit>(ct => _client.PostAsync("history/users/me/rewards/daily", EmptyContent, ct));

    public Task<ApiResponse<TestStatistics>> GetEasyTestStatisticsAsync() =>
        ExecuteAsync<TestStatistics>(ct => _client.GetAsync("history/users/me/tests/easy", ct));

    public Task<ApiResponse<TestStatistics>> GetHardTestStatisticsAsync() =>
        ExecuteAsync<TestStatistics>(ct => _client.GetAsync("history/users/me/tests/hard", ct));

    public Task<ApiResponse<TestStatistics>> GetMixedTestStatisticsAsync() =>
        ExecuteAsync<TestStatistics>(ct => _client.GetAsync("history/users/me/tests/mixed", ct));

    public Task<ApiResponse<EventGuesserStatistics>> GetEventGuesserStatisticsAsync() =>
        ExecuteAsync<EventGuesserStatistics>(ct => _client.GetAsync("history/users/me/event-guessers", ct));

    public Task<ApiResponse<PageResponse<UserTopicSummary>>> GetFavoritesAsync(FavoritesRequest request) =>
        ExecuteAsync<PageResponse<UserTopicSummary>>(ct =>
            _client.GetAsync($"history/users/me/favorites{request.ToQuery()}", ct));

    public Task<ApiResponse<TopicStatistics>> GetTopicsAsync(string topicId) =>
        ExecuteAsync<TopicStatistics>(ct => _client.GetAsync($"history/users/me/topics/{topicId}", ct));
}
