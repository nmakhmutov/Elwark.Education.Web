using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Course.Model;
using Education.Web.Client.Features.History.Clients.Course.Request;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.Course;

public interface IHistoryCourseClient
{
    Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request);

    Task<ApiResult<UserCourseDetailModel>> GetAsync(string id);

    Task<ApiResult<ExaminationBuilderModel>> GetExaminationAsync(string id);

    Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync();
}
