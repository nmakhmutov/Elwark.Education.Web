using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quest;

namespace Education.Web.Client.Features.History.Services.User;

public interface IHistoryUserService
{
    Task<ApiResult<ProfileModel>> GetProfileAsync();

    Task<ApiResult<PossessionsModel>> GetPossessionsAsync();

    Task<ApiResult<InventoryQuantityModel>> GetInventoryAsync(uint id);

    Task<ApiResult<BackpackModel>> GetBackpackAsync();

    Task<ApiResult<IReadOnlyCollection<WalletModel>>> GetWalletAsync();

    Task<ApiResult<UserQuestModel>> GetQuestAsync();

    Task<ApiResult<QuestsModel>> StartDailyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectDailyQuestAsync();

    Task<ApiResult<QuestsModel>> StartWeeklyQuestAsync();

    Task<ApiResult<QuestsModel>> CollectWeeklyQuestAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<AchievementsModel>> GetAchievementsAsync();
}
