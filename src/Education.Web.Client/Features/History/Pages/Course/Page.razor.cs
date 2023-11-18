using Education.Web.Client.Features.History.Services.Course;
using Education.Web.Client.Features.History.Services.Course.Model;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Course;

public sealed partial class Page
{
    private ApiResult<CourseModel> _result = ApiResult<CourseModel>.Loading();

    [Inject]
    private IHistoryCourseService CourseService { get; init; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync() =>
        _result = await CourseService.GetAsync(Id);

    private async Task StartCourseAsync(string id) =>
        _result = (await LearnerService.StartCourseAsync(id))
            .Map(x => _result.Unwrap() with { UserActivity = x });
}
