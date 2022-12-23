using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.User.Model;
using Education.Web.Client.Services.History.User.Request;
using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Quest;
using Education.Web.Client.Services.Model.Statistics;

namespace Education.Web.Client.Services.History.User;

public interface IHistoryUserService
{
    Task<ApiResult<HistoryProfileModel>> GetProfileAsync();

    Task<ApiResult<HistoryQuestModel>> GetQuestAsync();

    Task<ApiResult<DailyQuestModel>> StartDailyQuestAsync();

    Task<ApiResult<DailyQuestModel>> CollectDailyQuestAsync();

    Task<ApiResult<WeeklyQuestModel>> StartWeeklyQuestAsync();

    Task<ApiResult<WeeklyQuestModel>> CollectWeeklyQuestAsync();

    Task<ApiResult<DailyBonusModel>> ClaimDailyBonusAsync();

    Task<ApiResult<DailyBonusModel>> RejectDailyBonusAsync();

    Task<ApiResult<HistoryUserStatisticsModel>> GetStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetEasyTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetHardTestStatisticsAsync();

    Task<ApiResult<TestStatisticsModel>> GetMixedTestStatisticsAsync();

    Task<ApiResult<EventGuesserStatisticsModel>> GetEventGuesserStatisticsAsync();

    Task<ApiResult<AchievementsDetailModel>> GetAchievementsAsync();

    Task<ApiResult<PagingTokenModel<UserTopicOverviewModel>>> GetFavoritesAsync(FavoritesRequest request);

    Task<ApiResult<TopicStatisticsModel>> GetTopicsAsync(string topicId);

    Task<ApiResult<bool>> ToggleFavoriteAsync(string topicId);

    Task<ApiResult<Unit>> LikeAsync(string topicId);

    Task<ApiResult<Unit>> DislikeAsync(string topicId);

    Task<ApiResult<Unit>> RemoveInventoryAsync(string inventoryId);
}
