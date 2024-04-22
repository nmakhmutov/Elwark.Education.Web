using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations;

public sealed partial class Page
{
    private ApiResult<ExaminationModel> _examination = ApiResult<ExaminationModel>.Loading();

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
        _examination.Match(x => (double)x.CompletedQuestions / x.TotalQuestions * 100, _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _examination = await ExaminationClient.GetAsync(Id);
        _examination.MathError(x => HandlerError(x));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var examination = _examination.Unwrap();
        var result = await ExaminationClient.CheckAsync(Id, examination.Question.Id, answer);

        await result.MatchAsync(async x =>
        {
            if (x.IsCompleted)
                Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
            else
                _examination = await ExaminationClient.GetAsync(Id);
        });
    }

    private async Task OnExpiredAsync()
    {
        _examination = await ExaminationClient.GetAsync(Id);
        _examination.MathError(x => HandlerError(x));
    }

    private async Task OnUseInventory(uint id)
    {
        _examination = await ExaminationClient.ApplyInventoryAsync(Id, id);
        _examination.MathError(x => HandlerError(x));
    }

    private void HandlerError(Error error)
    {
        if (error.IsExaminationAlreadyCompleted() || error.IsExaminationExpired())
            Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
        else
            Snackbar.Add(error.Title, Severity.Error);
    }
}
