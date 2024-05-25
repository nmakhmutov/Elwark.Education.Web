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
    private ApiResult<ExaminationModel> _response = ApiResult<ExaminationModel>.Loading();

    [Inject]
    private IHistoryExaminationClient ExaminationClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    private double Progress =>
        _response.Match(x => Percentage.Calc(x.CompletedQuestions, x.TotalQuestions), _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _response = await ExaminationClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var examination = _response.Unwrap();
        var result = await ExaminationClient.CheckAsync(Id, examination.Question.Id, answer);

        await result.MatchAsync(async x =>
            {
                if (x.IsCompleted)
                    Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
                else
                    _response = await ExaminationClient.GetAsync(Id);
            },
            e => HandlerError(e)
        );
    }

    private async Task OnExpiredAsync()
    {
        _response = await ExaminationClient.GetAsync(Id);
        _response.MatchError(x => HandlerError(x));
    }

    private async Task OnUseInventory(uint id)
    {
        _response = await ExaminationClient.UseInventoryAsync(Id, id);
        _response.MatchError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsExaminationAlreadyCompleted() || error.IsExaminationExpired())
            Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
        else
            Snackbar.Add(error.Title, Severity.Error);
    }
}
