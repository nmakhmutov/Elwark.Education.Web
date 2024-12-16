using System.Collections.ObjectModel;
using Education.Client.Clients;
using Education.Client.Features.History.Clients.Search;
using Education.Client.Features.History.Clients.Search.Model;
using Education.Client.Features.History.Clients.Search.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Search;

public sealed partial class Page : ComponentBase
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly SearchRequest _request = new(string.Empty, true, [], 0, 20);
    private readonly IHistorySearchClient _searchClient;
    private IReadOnlyDictionary<string, int> _categories = ReadOnlyDictionary<string, int>.Empty;
    private ApiResult<SearchResultModel> _response = ApiResult<SearchResultModel>.Loading();

    public Page(IHistorySearchClient searchClient, NavigationManager navigation, IStringLocalizer<App> localizer)
    {
        _searchClient = searchClient;
        _navigation = navigation;
        _localizer = localizer;
    }

    [SupplyParameterFromQuery(Name = "q")]
    public string? Query { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; }

    [SupplyParameterFromQuery(Name = "category")]
    public string? Category { get; set; }

    private int TotalPages =>
        _response.Map(x => (int)double.Ceiling((double)x.Count / _request.Limit))
            .UnwrapOr(0);

    protected override async Task OnParametersSetAsync()
    {
        CurrentPage = Math.Max(CurrentPage, 1);

        if (string.IsNullOrWhiteSpace(Query))
        {
            _response = ApiResult<SearchResultModel>.Success(SearchResultModel.Empty);
            return;
        }

        _response = ApiResult<SearchResultModel>.Loading();

        _response = await _searchClient.SearchAsync(_request with
        {
            Q = Query,
            Offset = (CurrentPage - 1) * _request.Limit,
            Categories = string.IsNullOrWhiteSpace(Category) ? [] : [Category]
        });

        _categories = _response.Map(x => x.Categories)
            .UnwrapOrElse(() => ReadOnlyDictionary<string, int>.Empty);
    }

    private void ChangePage(int page)
    {
        CurrentPage = page;
        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("page", page));
    }

    private void OnSearchSubmit()
    {
        var parameters = new Dictionary<string, object?>
        {
            ["q"] = Query,
            ["category"] = string.IsNullOrWhiteSpace(Category) ? null : Category,
            ["page"] = 1
        };

        _navigation.NavigateTo(_navigation.GetUriWithQueryParameters(parameters));
    }
}
