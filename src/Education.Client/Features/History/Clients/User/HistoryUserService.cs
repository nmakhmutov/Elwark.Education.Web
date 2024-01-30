using Education.Client.Clients;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Clients.User.Request;

namespace Education.Client.Features.History.Clients.User;

internal sealed class HistoryUserService : IHistoryUserClient
{
    private readonly HistoryApiClient _api;

    public HistoryUserService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<MeOverviewModel>> GetMeAsync() =>
        _api.GetAsync<MeOverviewModel>("history/users/me");

    public Task<ApiResult<ProfileModel>> GetProfileAsync() =>
        _api.GetAsync<ProfileModel>("history/users/me/profile");

    public Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id) =>
        _api.GetAsync<InventoryQuantityModel>($"history/users/me/inventories/{id}");

    public Task<ApiResult<BackpackModel>> GetBackpackAsync() =>
        _api.GetAsync<BackpackModel>("history/users/me/backpack");

    public Task<ApiResult<FinanceModel>> GetFinancesAsync() =>
        _api.GetAsync<FinanceModel>("history/users/me/finances");

    public Task<ApiResult<UserAssignmentModel>> GetAssignmentsAsync() =>
        _api.GetAsync<UserAssignmentModel>("history/users/me/assignments");

    public Task<ApiResult<QuestModel[]>> StartAssignmentsAsync(StartAssignmentRequest request) =>
        _api.PostAsync<QuestModel[], StartAssignmentRequest>("history/users/me/assignments", request);

    public Task<ApiResult<QuestModel[]>> ClaimAssignmentsAsync(string id, ClaimAssignmentRequest request) =>
        _api.PostAsync<QuestModel[], ClaimAssignmentRequest>($"history/users/me/assignments/{id}", request);

    public Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync() =>
        _api.PutAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>("history/users/me/bonus/daily");

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>("history/users/me/achievements");
}
