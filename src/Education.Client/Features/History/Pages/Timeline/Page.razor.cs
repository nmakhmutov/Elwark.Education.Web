using Education.Client.Clients;
using Education.Client.Features.History.Clients.Article;
using Education.Client.Features.History.Clients.Article.Model;
using Education.Client.Features.History.Clients.Article.Request;
using Education.Client.Features.History.Pages.Timeline.Components;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Timeline;

public sealed partial class Page
{
    private int _currentYear;

    private ApiResult<PagingOffsetModel<TimelineOverviewModel>> _result =
        ApiResult<PagingOffsetModel<TimelineOverviewModel>>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryArticleClient ArticleClient { get; init; } = default!;

    [Inject]
    private IDialogService DialogService { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [SupplyParameterFromQuery(Name = "year")]
    public int Year { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        _currentYear = DateTime.UtcNow.Year;
        Year = NormalizeYear(Year);
        _result = await ArticleClient.GetAsync(new GetTimelineRequest(Year, 0, 36));
    }

    private void OnPreviousYearClick()
    {
        Year -= Year == 0 ? 2 : 1;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private void OnNextYearClick()
    {
        Year += Year == 0 ? 2 : 1;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private async Task OnYearClick()
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            CloseOnEscapeKey = true,
            FullWidth = true,
            NoHeader = true,
            CloseButton = false
        };

        var parameters = new DialogParameters
        {
            [nameof(YearChangerDialog.Year)] = Year
        };

        var dialog = await DialogService.ShowAsync<YearChangerDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
        if (result.Canceled)
            return;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", NormalizeYear((int)result.Data)));
    }

    private int NormalizeYear(int year) =>
        year switch
        {
            0 => _currentYear - 100,
            > 0 => Math.Min(year, _currentYear),
            _ => year
        };
}
