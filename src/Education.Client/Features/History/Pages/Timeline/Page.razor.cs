using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Features.History.Pages.Timeline.Components;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;

namespace Education.Client.Features.History.Pages.Timeline;

public sealed partial class Page : ComponentBase,
    IAsyncDisposable
{
    private readonly IHistoryArticleClient _articleClient;
    private readonly IDialogService _dialogService;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly IBrowserViewportService _viewportService;
    private int _currentYear;
    private Guid _subscriptionId;
    private TimelinePosition _timelinePosition = TimelinePosition.Start;

    private ApiResult<PagingOffsetModel<TimelineOverviewModel>> _response =
        ApiResult<PagingOffsetModel<TimelineOverviewModel>>.Loading();

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryArticleClient articleClient,
        IDialogService dialogService,
        IBrowserViewportService viewportService,
        NavigationManager navigation
    )
    {
        _localizer = localizer;
        _articleClient = articleClient;
        _dialogService = dialogService;
        _viewportService = viewportService;
        _navigation = navigation;
    }

    [SupplyParameterFromQuery(Name = "year")]
    public int Year { get; set; }

    public async ValueTask DisposeAsync() =>
        await _viewportService.UnsubscribeAsync(_subscriptionId);

    protected override async Task OnParametersSetAsync()
    {
        _currentYear = DateTime.UtcNow.Year;
        Year = NormalizeYear(Year);
        _response = await _articleClient.GetAsync(new GetTimelineRequest(Year, 0, 100));
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

    private void OnPreviousYearClick()
    {
        Year -= Year == 0 ? 2 : 1;

        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private void OnNextYearClick()
    {
        Year += Year == 0 ? 2 : 1;

        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private async Task OnYearClick()
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            CloseOnEscapeKey = true,
            FullWidth = true,
            CloseButton = false
        };

        var parameters = new DialogParameters<YearChangerDialog>
        {
            {
                x => x.Year, Year
            }
        };

        var dialog = await _dialogService.ShowAsync<YearChangerDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
        if (result is null || result.Canceled)
            return;

        _navigation.NavigateTo(_navigation.GetUriWithQueryParameter("year", NormalizeYear((int)result.Data!)));
    }

    private int NormalizeYear(int year) =>
        year switch
        {
            0 => _currentYear - 100,
            > 0 => Math.Min(year, _currentYear),
            _ => year
        };
}
