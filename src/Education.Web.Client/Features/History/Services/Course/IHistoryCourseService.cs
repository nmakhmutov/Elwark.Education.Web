using Education.Web.Client.Features.History.Services.Course.Model;
using Education.Web.Client.Features.History.Services.Course.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Course;

public interface IHistoryCourseService
{
    Task<ApiResult<PagingOffsetModel<UserCourseOverviewModel>>> GetAsync(GetCourseRequest request);

    Task<ApiResult<UserCourseDetailModel>> GetAsync(string id);
    
    Task<ApiResult<ExaminationBuilderModel>> GetExaminationAsync(string id);

    Task<ApiResult<UserCourseOverviewModel>> GetRandomAsync();
    
}
