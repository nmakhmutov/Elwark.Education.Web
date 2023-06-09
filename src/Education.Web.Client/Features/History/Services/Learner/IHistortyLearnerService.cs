using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Learner;

public interface IHistoryLearnerService
{
    public Task<ApiResult<UserCourseActivityModel>> StartCourseAsync(string courseId);
}