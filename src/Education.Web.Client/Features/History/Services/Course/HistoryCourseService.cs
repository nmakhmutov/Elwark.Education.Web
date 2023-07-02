using Education.Web.Client.Features.History.Services.Course.Model;
using Education.Web.Client.Features.History.Services.Course.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Course;

internal sealed class HistoryCourseService : IHistoryCourseService
{
    private readonly HistoryApiClient _api;

    public HistoryCourseService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserCourseOverviewModel>>("history/courses", request);

    public Task<ApiResult<CourseModel>> GetAsync(string id) =>
        _api.GetAsync<CourseModel>($"history/courses/{id}");

    public Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync() =>
        _api.GetAsync<UserCourseOverviewModel>("history/courses/random");
}
