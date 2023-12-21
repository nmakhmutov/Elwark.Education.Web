using Education.Client.Clients;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Course;

internal sealed class HistoryCourseClient : IHistoryCourseClient
{
    private readonly HistoryApiClient _api;

    public HistoryCourseClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserCourseOverviewModel>>("history/courses", request);

    public Task<ApiResult<UserCourseDetailModel>> GetAsync(string id) =>
        _api.GetAsync<UserCourseDetailModel>($"history/courses/{id}");

    public Task<ApiResult<ExaminationBuilderModel>> GetExaminationAsync(string id) =>
        _api.GetAsync<ExaminationBuilderModel>($"history/courses/{id}/examinations");

    public Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync() =>
        _api.GetAsync<UserCourseOverviewModel>("history/courses/random");
}
