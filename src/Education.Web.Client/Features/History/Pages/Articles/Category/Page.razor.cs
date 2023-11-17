using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Article.Request;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Articles.Category;

public sealed partial class Page
{
    private const int Limit = 20;
    private EpochType _epoch;
    private ApiResult<PagingOffsetModel<UserArticleOverviewModel>> _result =
        ApiResult<PagingOffsetModel<UserArticleOverviewModel>>.Loading();
    private GetArticlesRequest.SortType _sort;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryArticleService ArticleService { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Articles_Title"], null, true)
    ];
    
    [Parameter]
    public string? Category { get; set; }

    [SupplyParameterFromQuery(Name = "epoch")]
    public string? Epoch { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }

    private int TotalPages =>
        _result.Map(x => (int)double.Ceiling((double)x.Count / Limit))
            .UnwrapOr(1);

    protected override async Task OnParametersSetAsync()
    {
        _result = ApiResult<PagingOffsetModel<UserArticleOverviewModel>>.Loading();

        if (CurrentPage < 1)
            CurrentPage = 1;

        Enum.TryParse(Category, true, out _sort);
        Enum.TryParse(Epoch, true, out _epoch);

        _result = await ArticleService
            .GetAsync(new GetArticlesRequest(_epoch, _sort, (CurrentPage - 1) * Limit, Limit));
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

    private void OnEpochChange(EpochType epoch)
    {
        var value = epoch == EpochType.None ? null : epoch.ToFastString().ToLowerInvariant();

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("epoch", value));
    }

    private void OnSortChange(GetArticlesRequest.SortType sort) =>
        Navigation.NavigateTo(HistoryUrl.Content.Articles(sort, _epoch));
}
