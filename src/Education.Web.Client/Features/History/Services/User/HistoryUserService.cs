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

    public Task<ApiResult<PossessionsModel>> GetPossessionsAsync() =>
        _api.GetAsync<PossessionsModel>("history/users/me/possessions");
    
    public Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id) =>
        _api.GetAsync<InventoryQuantityModel>($"history/users/me/inventory/{id}");

    public Task<ApiResult<BackpackModel>> GetBackpackAsync() =>
        _api.GetAsync<BackpackModel>("history/users/me/backpack");

    public Task<ApiResult<IReadOnlyCollection<WalletModel>>> GetWalletAsync() =>
        _api.GetAsync<IReadOnlyCollection<WalletModel>>("history/users/me/wallet");

    public Task<ApiResult<UserAssignmentModel>> GetAssignmentsAsync() =>
        _api.GetAsync<UserAssignmentModel>("history/users/me/assignments");

    public Task<ApiResult<AssignmentsModel>> StartDailyAssignmentsAsync() =>
        _api.PostAsync<AssignmentsModel, object>("history/users/me/assignments/daily", new { Status = "Start" });

    public Task<ApiResult<AssignmentsModel>> CollectDailyAssignmentsAsync() =>
        _api.PostAsync<AssignmentsModel, object>("history/users/me/assignments/daily", new { Status = "Claim" });

    public Task<ApiResult<AssignmentsModel>> StartWeeklyAssignmentsAsync() =>
        _api.PostAsync<AssignmentsModel, object>("history/users/me/assignments/weekly", new { Status = "Start" });

    public Task<ApiResult<AssignmentsModel>> CollectWeeklyAssignmentsAsync() =>
        _api.PostAsync<AssignmentsModel, object>("history/users/me/assignments/weekly", new { Status = "Claim" });

    public Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync() =>
        _api.PutAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>("history/users/me/achievements");
}
