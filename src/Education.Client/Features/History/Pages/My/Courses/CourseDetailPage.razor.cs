using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Courses;

public sealed partial class CourseDetailPage : ComponentBase
{
    private ApiResult<CourseStatisticsModel> _result = ApiResult<CourseStatisticsModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync() =>
        _result = await LearnerClient.GetCourseAsync(Id);
}
