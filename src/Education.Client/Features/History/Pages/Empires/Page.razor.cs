using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;

namespace Education.Client.Features.History.Pages.Empires;

public sealed partial class Page : ComponentBase,
    IAsyncDisposable
{
    private readonly IHistoryArticleClient _articleClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IBrowserViewportService _viewportService;
    private Virtualize<EmpireOverviewModel> _empireVirtualize = new();
    private GetEmpiresRequest.SortType _sort = GetEmpiresRequest.SortType.Area;
    private Guid _subscriptionId;
    private TimelinePosition _timelinePosition = TimelinePosition.Start;

    public Page(
        IStringLocalizer<App> localizer,
        NavigationManager navigation,
        IBrowserViewportService viewportService,
        IHistoryArticleClient articleClient
    )
    {
        _localizer = localizer;
        _navigation = navigation;
        _viewportService = viewportService;
        _articleClient = articleClient;
    }

    [SupplyParameterFromQuery(Name = "by")]
    public string? Sort { get; set; }

    public async ValueTask DisposeAsync() =>
        await _viewportService.UnsubscribeAsync(_subscriptionId);

    protected override Task OnParametersSetAsync()
    {
        _sort = Map(Sort);

        return string.IsNullOrEmpty(Sort)
            ? Task.CompletedTask
            : _empireVirtualize.RefreshDataAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return Task.CompletedTask;

        _subscriptionId = Guid.NewGuid();
        var options = new ResizeOptions
        {
            NotifyOnBreakpointOnly = true,
            SuppressInitEvent = false
        };
        return _viewportService.SubscribeAsync(_subscriptionId, x => OnBreakpointChanged(x.Breakpoint), options);
    }

    private void SortChanged(GetEmpiresRequest.SortType sort) =>
        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("by", Map(sort)));

    private void OnBreakpointChanged(Breakpoint e)
    {
        var position = e is Breakpoint.Xs or Breakpoint.Sm
            ? TimelinePosition.Start
            : TimelinePosition.Alternate;

        if (_timelinePosition == position)
            return;

        _timelinePosition = position;
        InvokeAsync(StateHasChanged);
    }

    private async ValueTask<ItemsProviderResult<EmpireOverviewModel>> EmpiresProvider(ItemsProviderRequest request)
    {
        var result = await _articleClient.GetAsync(new GetEmpiresRequest(_sort, request.StartIndex, request.Count));

        return result.Map(x => new ItemsProviderResult<EmpireOverviewModel>(x.Items, (int)x.Count))
            .UnwrapOr(new ItemsProviderResult<EmpireOverviewModel>());
    }

    private static GetEmpiresRequest.SortType Map(string? sort) =>
        sort switch
        {
            "duration" => GetEmpiresRequest.SortType.Duration,
            "population" => GetEmpiresRequest.SortType.Population,
            _ => GetEmpiresRequest.SortType.Area
        };

    private static string Map(GetEmpiresRequest.SortType sort) =>
        sort switch
        {
            GetEmpiresRequest.SortType.Duration => "duration",
            GetEmpiresRequest.SortType.Population => "population",
            _ => "area"
        };
}
