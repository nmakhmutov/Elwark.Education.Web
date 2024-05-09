using Education.Client.Clients;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Course;

internal sealed class HistoryCourseClient : IHistoryCourseClient
{
    private const string Root = "history/courses";
    private readonly HistoryApiClient _api;

    public HistoryCourseClient(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request) =>
        _api.GetAsync<PagingOffsetModel<UserCourseOverviewModel>>(Root, request);

    public Task<ApiResult<UserCourseDetailModel>> GetAsync(string id) =>
        _api.GetAsync<UserCourseDetailModel>($"{Root}/{id}");

    public Task<ApiResult<ExaminationBuilderModel>> GetExaminationAsync(string id) =>
        _api.GetAsync<ExaminationBuilderModel>($"{Root}/{id}/examinations");

    public Task<ApiResult<TestCreationModel>> CreateExaminationAsync(string id, CreateExaminationRequest request) =>
        _api.PostAsync<TestCreationModel, CreateExaminationRequest>($"{Root}/{id}/examinations", request);

    public Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync() =>
        _api.GetAsync<UserCourseOverviewModel>($"{Root}/random");
}
