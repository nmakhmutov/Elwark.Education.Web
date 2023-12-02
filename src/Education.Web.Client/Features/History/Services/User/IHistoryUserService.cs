using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User;

public interface IHistoryUserService
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
