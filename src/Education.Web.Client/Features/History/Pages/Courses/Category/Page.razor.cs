using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Course;
using Education.Web.Client.Features.History.Services.Course.Request;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Courses.Category;

public sealed partial class Page
{
    private const int Limit = 20;
    private ApiResult<PagingOffsetModel<UserCourseOverviewModel>> _result =
        ApiResult<PagingOffsetModel<UserCourseOverviewModel>>.Loading();
    private GetCourseRequest.SortType _sort;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryCourseService CourseService { get; init; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;
    
    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Courses_Title"], null, true)
    ];
    
    [Parameter]
    public string? Category { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }
    
    private int TotalPages =>
        _result.Map(x => (int)double.Ceiling((double)x.Count / Limit))
            .UnwrapOr(1);

    protected override async Task OnParametersSetAsync()
    {
        _result = ApiResult<PagingOffsetModel<UserCourseOverviewModel>>.Loading();

        if (CurrentPage < 1)
            CurrentPage = 1;

        Enum.TryParse(Category, true, out _sort);

        _result = await CourseService
            .GetAsync(new GetCourseRequest(_sort, (CurrentPage - 1) * Limit, Limit));
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

    private void OnSortChange(GetCourseRequest.SortType sort) =>
        Navigation.NavigateTo(HistoryUrl.Content.Courses(sort));
}
