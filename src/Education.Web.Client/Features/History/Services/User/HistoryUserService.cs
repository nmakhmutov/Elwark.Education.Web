using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Test;
using Education.Web.Client.Features.History.Services.User.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User;

internal sealed class HistoryUserService : IHistoryUserService
{
    private readonly HistoryApiClient _api;

    public HistoryUserService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ProfileModel>> GetProfileAsync() =>
        _api.GetAsync<ProfileModel>("history/users/me/profile");

    public Task<ApiResult<BackpackModel>> GetBackpackAsync() =>
        _api.GetAsync<BackpackModel>("history/users/me/backpack");
    
    public Task<ApiResult<WalletModel>> GetWalletAsync() =>
        _api.GetAsync<WalletModel>("history/users/me/wallet");

    public Task<ApiResult<UserQuestModel>> GetQuestAsync() =>
        _api.GetAsync<UserQuestModel>("history/users/me/quests");

    public Task<ApiResult<QuestsModel>> StartDailyQuestAsync() =>
        _api.PostAsync<QuestsModel, object>("history/users/me/quests/daily", new { Status = "Start" });

    public Task<ApiResult<QuestsModel>> CollectDailyQuestAsync() =>
        _api.PostAsync<QuestsModel, object>("history/users/me/quests/daily", new { Status = "Claim" });

    public Task<ApiResult<QuestsModel>> StartWeeklyQuestAsync() =>
        _api.PostAsync<QuestsModel, object>("history/users/me/quests/weekly", new { Status = "Start" });

    public Task<ApiResult<QuestsModel>> CollectWeeklyQuestAsync() =>
        _api.PostAsync<QuestsModel, object>("history/users/me/quests/weekly", new { Status = "Claim" });

    public Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync() =>
        _api.PutAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<StatisticsModel>> GetStatisticsAsync() =>
        _api.GetAsync<StatisticsModel>("history/users/me/statistics");

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

    public Task<ApiResult<MoneyStatisticsModel>> GetSilverStatisticsAsync() =>
        _api.GetAsync<MoneyStatisticsModel>("history/users/me/monies/silver");

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>("history/users/me/achievements");

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetBookmarksAsync(BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>("history/users/me/bookmarks", request);

    public Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId) =>
        _api.GetAsync<ArticleStatisticsModel>($"history/users/me/articles/{articleId}");

    public Task<ApiResult<bool>> ToggleBookmarkAsync(string articleId) =>
        _api.PostAsync<bool>($"history/users/me/articles/{articleId}/bookmarks");

    public Task<ApiResult<Unit>> LikeAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/users/me/articles/{articleId}/likes");

    public Task<ApiResult<Unit>> DislikeAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/users/me/articles/{articleId}/dislikes");
}
