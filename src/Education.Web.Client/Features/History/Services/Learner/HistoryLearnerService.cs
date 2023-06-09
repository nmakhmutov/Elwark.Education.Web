using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Learner;

internal sealed class HistoryLearnerService : IHistoryLearnerService
{
    private readonly HistoryApiClient _api;

    public HistoryLearnerService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId) =>
        _api.PostAsync<UserCourseActivityModel>($"/history/learners/me/courses/{courseId}");
}
