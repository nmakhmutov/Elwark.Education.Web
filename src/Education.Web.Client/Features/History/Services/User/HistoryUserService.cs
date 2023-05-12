using Education.Web.Client.Features.History.Services.User.Model;
using Education.Web.Client.Features.History.Services.User.Model.EventGuesser;
using Education.Web.Client.Features.History.Services.User.Model.Quiz;
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

    public Task<ApiResult<QuizzesStatisticsModel>> GetQuizStatisticsAsync() =>
        _api.GetAsync<QuizzesStatisticsModel>("history/users/me/quizzes");

    public Task<ApiResult<QuizStatisticsModel>> GetEasyQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>("history/users/me/quizzes/easy");

    public Task<ApiResult<QuizStatisticsModel>> GetHardQuizStatisticsAsync() =>
        _api.GetAsync<QuizStatisticsModel>("history/users/me/quizzes/hard");

    public Task<ApiResult<EventGuessersStatisticsModel>> GetEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuessersStatisticsModel>("history/users/me/event-guessers");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetSmallEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/small");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetMediumEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/medium");

    public Task<ApiResult<EventGuesserStatisticsModel>> GetLargeEventGuesserStatisticsAsync() =>
        _api.GetAsync<EventGuesserStatisticsModel>("history/users/me/event-guessers/large");

    public Task<ApiResult<AchievementsModel>> GetAchievementsAsync() =>
        _api.GetAsync<AchievementsModel>("history/users/me/achievements");

    public Task<ApiResult<PagingTokenModel<UserArticleOverviewModel>>> GetArticleBookmarksAsync(
        BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<UserArticleOverviewModel>>("history/users/me/article-bookmarks", request);

    public Task<ApiResult<ArticleStatisticsModel>> GetArticlesAsync(string articleId) =>
        _api.GetAsync<ArticleStatisticsModel>($"history/users/me/articles/{articleId}");

    public Task<ApiResult<bool>> ToggleArticleBookmarkAsync(string articleId) =>
        _api.PostAsync<bool>($"history/users/me/articles/{articleId}/bookmarks");

    public Task<ApiResult<Unit>> LikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/users/me/articles/{articleId}/likes");

    public Task<ApiResult<Unit>> DislikeArticleAsync(string articleId) =>
        _api.PostAsync<Unit>($"history/users/me/articles/{articleId}/dislikes");

    public Task<ApiResult<PagingTokenModel<CourseOverviewModel>>> GetCourseBookmarksAsync(BookmarksRequest request) =>
        _api.GetAsync<PagingTokenModel<CourseOverviewModel>>("history/users/me/course-bookmarks", request);

    public Task<ApiResult<bool>> ToggleCourseBookmarkAsync(string courseId) =>
        _api.PostAsync<bool>($"history/users/me/courses/{courseId}/bookmarks");

    public Task<ApiResult<Unit>> LikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/users/me/courses/{courseId}/likes");

    public Task<ApiResult<Unit>> DislikeCourseAsync(string courseId) =>
        _api.PostAsync<Unit>($"history/users/me/courses/{courseId}/dislikes");
}
