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
    private EpochType _epoch;

    private ApiResult<PagingOffsetModel<UserArticleOverviewModel>> _response =
        ApiResult<PagingOffsetModel<UserArticleOverviewModel>>.Loading();

    private GetArticlesRequest.SortType _sort;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryArticleClient ArticleClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Articles_Title"], null, true)
    ];

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

        _response = await ArticleClient
            .GetAsync(new GetArticlesRequest(_epoch, _sort, (CurrentPage - 1) * Limit, Limit));
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

    private void OnEpochChange(EpochType epoch) =>
        Navigation.NavigateTo(HistoryUrl.Content.Articles(_sort, epoch));

    private void OnSortChange(GetArticlesRequest.SortType sort) =>
        Navigation.NavigateTo(HistoryUrl.Content.Articles(sort, _epoch));
}
