using Education.Client.Clients;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Clients.User.Request;

namespace Education.Client.Features.History.Clients.User;

internal sealed class HistoryUserService : IHistoryUserClient
{
    private readonly HistoryApiClient _api;
    private const string Root = "history/users";

    public HistoryUserService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<MeOverviewModel>> GetMeAsync() =>
        _api.GetAsync<MeOverviewModel>($"{Root}/me");

    public Task<ApiResult<ProfileModel>> GetProfileAsync() =>
        _api.GetAsync<ProfileModel>($"{Root}/me/profile");

    public Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id) =>
        _api.GetAsync<InventoryQuantityModel>($"{Root}/me/inventories/{id}");

    public Task<ApiResult<BackpackModel>> GetBackpackAsync() =>
        _api.GetAsync<BackpackModel>($"{Root}/me/backpack");

    public Task<ApiResult<FinanceModel>> GetFinancesAsync() =>
        _api.GetAsync<FinanceModel>($"{Root}/me/finances");

    public Task<ApiResult<UserAssignmentModel>> GetAssignmentsAsync() =>
        _api.GetAsync<UserAssignmentModel>($"{Root}/me/assignments");

    public Task<ApiResult<QuestModel[]>> StartAssignmentsAsync(StartAssignmentRequest request) =>
        _api.PostAsync<QuestModel[], StartAssignmentRequest>($"{Root}/me/assignments", request);

    public Task<ApiResult<QuestModel[]>> ClaimAssignmentsAsync(string id, ClaimAssignmentRequest request) =>
        _api.PostAsync<QuestModel[], ClaimAssignmentRequest>($"{Root}/me/assignments/{id}", request);

    public Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync() =>
        _api.PutAsync<DailyBonusModel>($"{Root}/me/bonus/daily");

    public Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync() =>
        _api.DeleteAsync<DailyBonusModel>($"{Root}/me/bonus/daily");

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>($"{Root}/me/achievements");
}
