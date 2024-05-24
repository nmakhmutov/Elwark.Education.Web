using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.DateGuessers.Conclusion;

public sealed partial class Page : ComponentBase
{
    private double _progress;
    private ApiResult<DateGuesserConclusionModel> _response = ApiResult<DateGuesserConclusionModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryDateGuesserClient DateGuesserClient { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _response = await DateGuesserClient.GetConclusionAsync(Id);
        _response.Match(
            x => _progress = Percentage.Calc(x.Score.Total, x.MaxScore),
            e =>
            {
                if (e.IsDateGuesserNotFound())
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Index);
            }
        );
    }
}
