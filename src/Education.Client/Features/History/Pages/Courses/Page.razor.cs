using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Courses;

public sealed partial class Page : ComponentBase
{
    private const int Limit = 20;

    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryCourseClient _courseClient;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;

    private ApiResult<PagingOffsetModel<UserCourseOverviewModel>> _response =
        ApiResult<PagingOffsetModel<UserCourseOverviewModel>>.Loading();

    private GetCourseRequest.SortType _sort;

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryCourseClient courseClient,
        IHistoryLearnerClient learnerClient,
        NavigationManager navigation
    )
    {
        _localizer = localizer;
        _courseClient = courseClient;
        _learnerClient = learnerClient;
        _navigation = navigation;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["Courses_Title"], null, true)
        ];
    }

    [SupplyParameterFromQuery(Name = "category")]
    public string? Category { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }

    private int TotalPages =>
        _response.Map(x => (int)double.Ceiling((double)x.Count / Limit))
            .UnwrapOr(1);

    protected override async Task OnParametersSetAsync()
    {
        _response = ApiResult<PagingOffsetModel<UserCourseOverviewModel>>.Loading();

        if (CurrentPage < 1)
            CurrentPage = 1;

        Enum.TryParse(Category, true, out _sort);

        _response = await _courseClient
            .GetAsync(new GetCourseRequest(_sort, (CurrentPage - 1) * Limit, Limit));
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

    private void OnSortChange(GetCourseRequest.SortType sort) =>
        _navigation.NavigateTo(HistoryUrl.Content.Courses(sort));
}
