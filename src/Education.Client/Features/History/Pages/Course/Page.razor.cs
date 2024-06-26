using Education.Client.Clients;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Learner;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Course;

public sealed partial class Page : ComponentBase
{
    private ApiResult<UserCourseDetailModel> _response = ApiResult<UserCourseDetailModel>.Loading();

    [Inject]
    private IHistoryCourseClient CourseClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync() =>
        _response = await CourseClient.GetAsync(Id);

    private async Task StartCourseAsync(string id)
    {
        var response = await LearnerClient.StartCourseAsync(id);
        _response = response.Map(x => _response.Unwrap() with
        {
            Activity = x
        });
    }
}
