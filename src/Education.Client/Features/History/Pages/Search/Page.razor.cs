using System.Collections.ObjectModel;
using Education.Client.Clients;
using Education.Client.Features.History.Clients.Search;
using Education.Client.Features.History.Clients.Search.Model;
using Education.Client.Features.History.Clients.Search.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Search;

public sealed partial class Page
{
    private readonly SearchRequest _request = new(string.Empty, true, [], 0, 20);
    private IReadOnlyDictionary<string, int> _categories = new Dictionary<string, int>();
    private ApiResult<SearchResultModel> _result = ApiResult<SearchResultModel>.Loading();

    [Inject]
    private IHistorySearchClient SearchClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

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

        _result = await SearchClient.SearchAsync(
            _request with
            {
                Q = Query,
                Offset = (CurrentPage - 1) * _request.Limit,
                Categories = string.IsNullOrWhiteSpace(Category) ? [] : [Category]
            });

        _categories = _result.Map(x => x.Categories)
            .UnwrapOrElse(() => ReadOnlyDictionary<string, int>.Empty);
    }

    private void OnPagination(int page)
    {
        CurrentPage = page;
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("page", page < 2 ? null : page));
    }

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
