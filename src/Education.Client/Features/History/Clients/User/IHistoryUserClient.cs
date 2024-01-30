using Education.Client.Clients;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Features.History.Clients.User.Request;

namespace Education.Client.Features.History.Clients.User;

public interface IHistoryUserClient
{
    Task<ApiResult<MeOverviewModel>> GetMeAsync();

    Task<ApiResult<ProfileModel>> GetProfileAsync();

    Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id);

    Task<ApiResult<BackpackModel>> GetBackpackAsync();

    Task<ApiResult<FinanceModel>> GetFinancesAsync();

    Task<ApiResult<UserAssignmentModel>> GetAssignmentsAsync();

    Task<ApiResult<QuestModel[]>> StartAssignmentsAsync(StartAssignmentRequest request);

    Task<ApiResult<QuestModel[]>> ClaimAssignmentsAsync(string id, ClaimAssignmentRequest request);

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();
}
