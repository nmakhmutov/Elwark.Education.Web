using Education.Client.Clients;
using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models.Quest;

namespace Education.Client.Features.History.Clients.User;

public interface IHistoryUserClient
{
    Task<ApiResult<ProfileModel>> GetProfileAsync();

    Task<ApiResult<ProfileStatisticsModel>> GetStatisticsAsync();

    Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id);

    Task<ApiResult<BackpackModel>> GetBackpackAsync();

    Task<ApiResult<IReadOnlyCollection<WalletModel>>> GetWalletAsync();

    Task<ApiResult<UserAssignmentModel>> GetAssignmentsAsync();

    Task<ApiResult<AssignmentsModel>> StartDailyAssignmentsAsync();

    Task<ApiResult<AssignmentsModel>> CollectDailyAssignmentsAsync();

    Task<ApiResult<AssignmentsModel>> StartWeeklyAssignmentsAsync();

    Task<ApiResult<AssignmentsModel>> CollectWeeklyAssignmentsAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();
}