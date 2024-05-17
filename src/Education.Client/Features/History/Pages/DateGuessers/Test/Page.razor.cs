using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.DateGuessers.Test;

public sealed partial class Page: ComponentBase
{
    private ApiResult<DateGuesserModel> _guesser = ApiResult<DateGuesserModel>.Loading();

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
        _guesser.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _guesser = await DateGuesserClient.GetAsync(Id);
        _guesser.MatchError(e => HandlerError(e));
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
                    _guesser = await DateGuesserClient.GetAsync(Id);
            },
            e => HandlerError(e)
        );
    }

    private async Task OnUseInventory(uint id)
    {
        _guesser = await DateGuesserClient.UseInventoryAsync(Id, id);
        _guesser.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsDateGuesserNotFound() || error.IsDateGuesserAlreadyCompleted())
            Navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
        else
            Snackbar.Add(error.Title, Severity.Error);
    }
}
