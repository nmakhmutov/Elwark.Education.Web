using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Course;
using Education.Web.Client.Features.History.Clients.Course.Model;
using Education.Web.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Course;

public sealed partial class Page
{
    private ApiResult<UserCourseDetailModel> _result = ApiResult<UserCourseDetailModel>.Loading();

    [Inject]
    private IHistoryCourseClient CourseClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync() =>
        _result = await CourseClient.GetAsync(Id);

    private async Task StartCourseAsync(string id) =>
        _result = (await LearnerClient.StartCourseAsync(id))
            .Map(x => _result.Unwrap() with { Activity = x });
}
