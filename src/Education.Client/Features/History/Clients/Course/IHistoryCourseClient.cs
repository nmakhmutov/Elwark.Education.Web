using Education.Client.Clients;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Models;
using Education.Client.Models.Test;

namespace Education.Client.Features.History.Clients.Course;

public interface IHistoryCourseClient
{
    Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request);

    Task<ApiResult<UserCourseDetailModel>> GetAsync(string id);

    Task<ApiResult<ExaminationBuilderModel>> GetExaminationAsync(string id);

    Task<ApiResult<TestCreationModel>> CreateExaminationAsync(string id, CreateExaminationRequest request);

    Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync();
}
