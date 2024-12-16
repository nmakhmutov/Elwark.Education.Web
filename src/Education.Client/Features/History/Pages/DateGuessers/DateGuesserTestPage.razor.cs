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
    private readonly IHistoryDateGuesserClient _dateGuesserClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly ISnackbar _snackbar;
    private ApiResult<DateGuesserModel> _response = ApiResult<DateGuesserModel>.Loading();

    public DateGuesserTestPage(IStringLocalizer<App> localizer, IHistoryDateGuesserClient dateGuesserClient,
        ISnackbar snackbar, NavigationManager navigation)
    {
        _localizer = localizer;
        _dateGuesserClient = dateGuesserClient;
        _snackbar = snackbar;
        _navigation = navigation;
    }

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private double Progress =>
        _response.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _response = await _dateGuesserClient.GetAsync(Id);
        _response.MatchError(e => HandlerError(e));
    }

    private async Task OnValidSubmit(DateGuesserForm.Model model)
    {
        var year = model.Year.GetValueOrDefault();
        var request = new CheckRequest(model.IsCe ? year : -year, model.Month, model.Day);

        var result = await _dateGuesserClient.CheckAsync(Id, model.QuestionId, request);

        await result.MatchAsync(async x =>
            {
                if (x.IsCompleted)
                    _navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
                else
                    _response = await _dateGuesserClient.GetAsync(Id);
            },
            e => HandlerError(e)
        );
    }

    private async Task OnUseInventory(uint id)
    {
        _response = await _dateGuesserClient.UseInventoryAsync(Id, id);
        _response.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsDateGuesserNotFound() || error.IsDateGuesserAlreadyCompleted())
            _navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
        else
            _snackbar.Add(error.Title, Severity.Error);
    }
}
