using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services.DateGuesser;
using Education.Web.Client.Features.History.Services.DateGuesser.Model;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Features.History.Pages.DateGuessers.Conclusion;

public sealed partial class Page
{
    private double _progress;
    private ApiResult<DateGuesserConclusionModel> _result = ApiResult<DateGuesserConclusionModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryDateGuesserService DateGuesserService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _result = await DateGuesserService.GetConclusionAsync(Id);
        _result.Match(
            x => _progress = Math.Round((double)x.Score.Total / x.MaxScore * 100),
            e =>
            {
                if (e.IsDateGuesserNotFound())
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Index);
            }
        );
    }
}
