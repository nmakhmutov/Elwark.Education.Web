using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User;

internal sealed class HistoryUserService : IHistoryUserService
{
    private readonly HistoryApiClient _api;

    public HistoryUserService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ProfileModel>> GetProfileAsync() =>
        _api.GetAsync<ProfileModel>("history/users/me/profile");

    public Task<ApiResult<InventoryModel>> GetInventoryAsync() =>
        _api.GetAsync<InventoryModel>("history/users/me/inventory");

    public Task<ApiResult<BackpackModel>> GetBackpackAsync() =>
        _api.GetAsync<BackpackModel>("history/users/me/backpack");

    public Task<ApiResult<IReadOnlyCollection<WalletModel>>> GetWalletAsync() =>
        _api.GetAsync<IReadOnlyCollection<WalletModel>>("history/users/me/wallet");

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

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>("history/users/me/achievements");
}
