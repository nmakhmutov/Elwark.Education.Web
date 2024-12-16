using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations;

public sealed partial class ExaminationTestPage : ComponentBase
{
    private readonly IHistoryExaminationClient _examinationClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly ISnackbar _snackbar;
    private ApiResult<ExaminationModel> _response = ApiResult<ExaminationModel>.Loading();

    public ExaminationTestPage(IHistoryExaminationClient examinationClient, IStringLocalizer<App> localizer,
        NavigationManager navigation, ISnackbar snackbar)
    {
        _examinationClient = examinationClient;
        _localizer = localizer;
        _navigation = navigation;
        _snackbar = snackbar;
    }

    [Parameter]
    public required string Id { get; set; }

    private double Progress =>
        _response.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _response = await _examinationClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var examination = _response.Unwrap();
        var result = await _examinationClient.CheckAsync(Id, examination.Question.Id, answer);

        await result.MatchAsync(async x =>
            {
                if (x.IsCompleted)
                    _navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
                else
                    _response = await _examinationClient.GetAsync(Id);
            },
            e => HandlerError(e)
        );
    }

    private async Task OnExpiredAsync()
    {
        _response = await _examinationClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnUseInventory(uint id)
    {
        _response = await _examinationClient.UseInventoryAsync(Id, id);
        _response.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsExaminationAlreadyCompleted() || error.IsExaminationExpired())
            _navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
        else
            _snackbar.Add(error.Title, Severity.Error);
    }
}
