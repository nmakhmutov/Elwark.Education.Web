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
    private readonly GetTimelineRequest _request = new(0, 0, 20);

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
        Year = NormalizeYear(Year);
        _result = await ArticleClient.GetAsync(_request with { Year = Year });
    }

    private void OnPreviousYearClick()
    {
        Year--;

        if (Year == 0)
            Year--;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private void OnNextYearClick()
    {
        Year++;

        if (Year == 0)
            Year++;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", NormalizeYear(Year)));
    }

    private async Task OnYearClick()
    {
        var options = new DialogOptions
        {
            FullWidth = true,
            MaxWidth = MaxWidth.Small,
            CloseButton = false,
            NoHeader = true
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

    private static int NormalizeYear(int year)
    {
        if (year == 0)
            return DateTime.UtcNow.Year - 100;

        return Math.Min(year, DateTime.UtcNow.Year);
    }
}
