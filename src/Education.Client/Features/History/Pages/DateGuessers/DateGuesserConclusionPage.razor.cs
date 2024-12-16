using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.DateGuessers;

public sealed partial class DateGuesserConclusionPage : ComponentBase
{
    private readonly IHistoryDateGuesserClient _dateGuesserClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private double _progress;
    private ApiResult<DateGuesserConclusionModel> _response = ApiResult<DateGuesserConclusionModel>.Loading();

    public DateGuesserConclusionPage(
        IStringLocalizer<App> localizer,
        IHistoryDateGuesserClient dateGuesserClient,
        NavigationManager navigation
    )
    {
        _localizer = localizer;
        _dateGuesserClient = dateGuesserClient;
        _navigation = navigation;
    }

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _response = await _dateGuesserClient.GetConclusionAsync(Id);
        _response.Match(
            x => _progress = Percentage.Calc(x.Score.Total, x.MaxScore),
            e =>
            {
                if (e.IsDateGuesserNotFound())
                    _navigation.NavigateTo(HistoryUrl.DateGuesser.Index);
            }
        );
    }
}
