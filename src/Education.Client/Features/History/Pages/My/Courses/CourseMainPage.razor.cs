using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.My.Courses;

public partial class CourseMainPage : ComponentBase
{
    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["User_Dashboard_Title"], HistoryUrl.User.MyDashboard),
        new BreadcrumbItem(L["Courses_RecentActivity_Title"], null, true)
    ];
}
