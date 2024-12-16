using Education.Client.Clients;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Articles;

public sealed partial class Page : ComponentBase
{
    private const int Limit = 20;

    private readonly IHistoryArticleClient _articleClient;
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private EpochType _epoch;

    private ApiResult<PagingOffsetModel<UserArticleOverviewModel>> _response =
        ApiResult<PagingOffsetModel<UserArticleOverviewModel>>.Loading();

    private GetArticlesRequest.SortType _sort;

    public Page(IStringLocalizer<App> localizer, IHistoryArticleClient articleClient,
        IHistoryLearnerClient learnerClient, NavigationManager navigation)
    {
        _localizer = localizer;
        _articleClient = articleClient;
        _learnerClient = learnerClient;
        _navigation = navigation;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["Articles_Title"], null, true)
        ];
    }

    [SupplyParameterFromQuery(Name = "category")]
    public string? Category { get; set; }

    [SupplyParameterFromQuery(Name = "epoch")]
    public string? Epoch { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }

    private int TotalPages =>
        _response.Map(x => (int)double.Ceiling((double)x.Count / Limit))
            .UnwrapOr(1);

    protected override async Task OnParametersSetAsync()
    {
        _response = ApiResult<PagingOffsetModel<UserArticleOverviewModel>>.Loading();

        if (CurrentPage < 1)
            CurrentPage = 1;

        Enum.TryParse(Category, true, out _sort);
        Enum.TryParse(Epoch, true, out _epoch);

        _response = await _articleClient
            .GetAsync(new GetArticlesRequest(_epoch, _sort, (CurrentPage - 1) * Limit, Limit));
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

    private void OnEpochChange(EpochType epoch) =>
        _navigation.NavigateTo(HistoryUrl.Content.Articles(_sort, epoch));

    private void OnSortChange(GetArticlesRequest.SortType sort) =>
        _navigation.NavigateTo(HistoryUrl.Content.Articles(sort, _epoch));
}
