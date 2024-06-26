using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;
using Education.Client.Features.History.Pages.DateGuessers.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.DateGuessers;

public sealed partial class DateGuesserTestPage : ComponentBase
{
    private ApiResult<DateGuesserModel> _response = ApiResult<DateGuesserModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryDateGuesserClient DateGuesserClient { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private double Progress =>
        _response.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _response = await DateGuesserClient.GetAsync(Id);
        _response.MatchError(e => HandlerError(e));
    }

    private async Task OnValidSubmit(DateGuesserForm.Model model)
    {
        var year = model.Year.GetValueOrDefault();
        var request = new CheckRequest(model.IsCe ? year : -year, model.Month, model.Day);

        var result = await DateGuesserClient.CheckAsync(Id, model.QuestionId, request);

        await result.MatchAsync(async x =>
            {
                if (x.IsCompleted)
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
                else
                    _response = await DateGuesserClient.GetAsync(Id);
            },
            e => HandlerError(e)
        );
    }

    private async Task OnUseInventory(uint id)
    {
        _response = await DateGuesserClient.UseInventoryAsync(Id, id);
        _response.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsDateGuesserNotFound() || error.IsDateGuesserAlreadyCompleted())
            Navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
        else
            Snackbar.Add(error.Title, Severity.Error);
    }
}
