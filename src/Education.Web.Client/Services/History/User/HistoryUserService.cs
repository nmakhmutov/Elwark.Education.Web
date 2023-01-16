using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.User.Model;
using Education.Web.Client.Services.History.User.Model.EventGuesser;
using Education.Web.Client.Services.History.User.Model.Test;
using Education.Web.Client.Services.History.User.Request;
using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Quest;

namespace Education.Web.Client.Services.History.User;

internal sealed class HistoryUserService : IHistoryUserService
{
    private readonly ApiClient _api;

    public HistoryUserService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<HistoryProfileModel>> GetProfileAsync() =>
        _api.GetAsync<HistoryProfileModel>("history/users/me");

    public Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsDetailModel>("history/users/me/achievements");

    public Task<ApiResult<HistoryQuestModel>> GetQuestAsync() =>
        _api.GetAsync<HistoryQuestModel>("history/users/me/quests");

    public Task<ApiResult<DailyQuestModel>> StartDailyQuestAsync() =>
        _api.PostAsync<DailyQuestModel, object>("history/users/me/quests/daily", new { Status = "Start" });

    public Task<ApiResult<DailyQuestModel>> CollectDailyQuestAsync() =>
        _api.PostAsync<DailyQuestModel, object>("history/users/me/quests/daily", new { Status = "Collect" });

    public Task<ApiResult<WeeklyQuestModel>> StartWeeklyQuestAsync() =>
        _api.PostAsync<WeeklyQuestModel, object>("history/users/me/quests/weekly", new { Status = "Start" });

    public Task<ApiResult<WeeklyQuestModel>> CollectWeeklyQuestAsync() =>
        _api.PostAsync<WeeklyQuestModel, object>("history/users/me/quests/weekly", new { Status = "Collect" });

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

    public Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/small");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/medium");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/large");

    public Task<ApiResult<PagingTokenModel<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request) =>
        _api.GetAsync<PagingTokenModel<UserTopicOverviewModel>>("history/users/me/favorites", request);

    public Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId) =>
        _api.GetAsync<TopicStatisticsModel>($"history/users/me/topics/{topicId}");

    public Task<ApiResult<bool>> ToggleFavoriteAsync(string topicId) =>
        _api.PostAsync<bool>($"history/users/me/topics/{topicId}/favorites");

    public Task<ApiResult<Unit>> LikeAsync(string topicId) =>
        _api.PostAsync<Unit>($"history/users/me/topics/{topicId}/likes");

    public Task<ApiResult<Unit>> DislikeAsync(string topicId) =>
        _api.PostAsync<Unit>($"history/users/me/topics/{topicId}/dislikes");

    public Task<ApiResult<Unit>> RemoveInventoryAsync(string inventoryId) =>
        _api.DeleteAsync<Unit>($"history/users/me/inventories/{inventoryId}");
}
