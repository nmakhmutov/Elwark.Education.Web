using Education.Client.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Model;
using Education.Client.Shared.Customer;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.My.Courses;

public sealed partial class CourseDetailPage : ComponentBase
{
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private ApiResult<CourseStatisticsModel> _response = ApiResult<CourseStatisticsModel>.Loading();

    public CourseDetailPage(IStringLocalizer<App> localizer, IHistoryLearnerClient learnerClient)
    {
        _localizer = localizer;
        _learnerClient = learnerClient;
    }

    [CascadingParameter]
    private CustomerState Customer { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync() =>
        _response = await _learnerClient.GetCourseAsync(Id);
}
