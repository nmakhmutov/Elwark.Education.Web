using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Features.History.Clients.Learner.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Courses;

public partial class CourseMainPage : ComponentBase
{
    private ApiResult<PagingTokenModel<UserCourseOverviewModel>> _response =
        ApiResult<PagingTokenModel<UserCourseOverviewModel>>.Loading();

    [Inject]
    public IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Courses_RecentActivity_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _response = await LearnerClient.GetCoursesAsync(new CourseActivityRequest(50));
}
