using System.Collections.ObjectModel;
using Education.Web.Client.Features.History.Services.Search;
using Education.Web.Client.Features.History.Services.Search.Model;
using Education.Web.Client.Features.History.Services.Search.Request;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.Search;

public sealed partial class Page
{
    private readonly SearchRequest _request = new(string.Empty, true, Array.Empty<string>(), 0, 20);
    private IReadOnlyDictionary<string, int> _categories = new Dictionary<string, int>();
    private ApiResult<SearchResultModel> _result = ApiResult<SearchResultModel>.Loading();

    [Inject]
    private IHistorySearchService HistorySearchService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [SupplyParameterFromQuery(Name = "q")]
    public string? Query { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }

    [SupplyParameterFromQuery(Name = "category")]
    public string? Category { get; set; }

    private int TotalPages =>
        _result.Map(x => (int)double.Ceiling((double)x.Count / _request.Limit))
            .UnwrapOr(1);

    protected override async Task OnParametersSetAsync()
    {
        _result = ApiResult<SearchResultModel>.Loading();

        if (CurrentPage < 1)
            CurrentPage = 1;

        if (Query is not { Length: > 1 })
        {
            _result = ApiResult<SearchResultModel>.Success(SearchResultModel.Empty);
            return;
        }

        _result = await HistorySearchService.SearchAsync(
            _request with
            {
                Q = Query,
                Offset = (CurrentPage - 1) * _request.Limit,
                Categories = string.IsNullOrWhiteSpace(Category) ? Array.Empty<string>() : new[] { Category }
            });

        _categories = _result.Map(x => x.Categories)
            .UnwrapOrElse(() => ReadOnlyDictionary<string, int>.Empty);
    }

    private void OnPagination(int page) =>
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("page", page));

    private void OnSearchSubmit()
    {
        var parameters = new Dictionary<string, object?>
        {
            ["q"] = Query,
            ["category"] = string.IsNullOrWhiteSpace(Category) ? null : Category,
            ["page"] = 1
        };

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameters(parameters));
    }
}
