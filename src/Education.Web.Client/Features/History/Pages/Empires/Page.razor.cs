using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Article.Model;
using Education.Web.Client.Features.History.Services.Article.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;

namespace Education.Web.Client.Features.History.Pages.Empires;

public sealed partial class Page
{
    private Virtualize<EmpireOverviewModel> _empireVirtualize = new();
    private GetEmpiresRequest.SortType _sort = GetEmpiresRequest.SortType.Area;
    private Guid _subscriptionId;
    private TimelinePosition _timelinePosition = TimelinePosition.Start;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IBrowserViewportService ViewportService { get; set; } = default!;

    [Inject]
    private IHistoryArticleService ArticleService { get; set; } = default!;

    [SupplyParameterFromQuery(Name = "by")]
    public string? Sort { get; set; }

    public async ValueTask DisposeAsync() =>
        await ViewportService.UnsubscribeAsync(_subscriptionId);

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
        var options = new ResizeOptions { NotifyOnBreakpointOnly = true, SuppressInitEvent = false };
        return ViewportService.SubscribeAsync(_subscriptionId, x => OnBreakpointChanged(x.Breakpoint), options);
    }

    private void SortChanged(GetEmpiresRequest.SortType sort) =>
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("by", Map(sort)));

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
        var result = await ArticleService.GetAsync(new GetEmpiresRequest(_sort, request.StartIndex, request.Count));

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
