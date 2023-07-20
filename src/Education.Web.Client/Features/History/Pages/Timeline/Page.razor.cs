using Education.Web.Client.Features.History.Pages.Timeline.Components;
using Education.Web.Client.Features.History.Services.Article;
using Education.Web.Client.Features.History.Services.Article.Model;
using Education.Web.Client.Features.History.Services.Article.Request;
using Education.Web.Client.Http;
using Education.Web.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Timeline;

public sealed partial class Page
{
    private readonly GetTimelineRequest _request = new(0, 0, 20);

    private ApiResult<PagingOffsetModel<TimelineOverviewModel>> _result =
        ApiResult<PagingOffsetModel<TimelineOverviewModel>>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryArticleService ArticleService { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [SupplyParameterFromQuery(Name = "year")]
    public int Year { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Year == 0)
            Year = DateTime.Now.Year - 100;

        _result = await ArticleService.GetAsync(_request with { Year = Year });
    }

    private void OnPreviousYearClick()
    {
        Year--;

        if (Year == 0)
            Year--;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", Year));
    }

    private void OnNextYearClick()
    {
        Year++;

        if (Year == 0)
            Year++;

        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", Year));
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

        var year = (int)result.Data;
        Navigation.NavigateTo(Navigation.GetUriWithQueryParameter("year", year));
    }
}
