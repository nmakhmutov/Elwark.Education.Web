using Education.Client.Clients;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations;

public sealed partial class Page
{
    private ApiResult<ExaminationModel> _result = ApiResult<ExaminationModel>.Loading();

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
        _result.Match(x => (double)x.CompletedQuestions / x.TotalQuestions * 100, _ => 0, () => 0);

    protected override async Task OnInitializedAsync()
    {
        _result = await ExaminationClient.GetAsync(Id);
        _result.MathError(_ => Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id)));
    }

    private async Task OnAnswerAsync(UserAnswerModel answer)
    {
        var examination = _result.Unwrap();
        var result = await ExaminationClient.CheckAsync(Id, examination.Question.Id, answer);

        await result.MatchAsync(async x =>
        {
            if (x.IsCompleted)
                Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
            else
                _result = await ExaminationClient.GetAsync(Id);
        });
    }

    private Task OnExpiredAsync()
    {
        Navigation.NavigateTo(HistoryUrl.Examination.Conclusion(Id));
        return Task.CompletedTask;
    }

    private async Task OnUseInventory(uint id)
    {
        _result = await ExaminationClient.ApplyInventoryAsync(Id, id);
        _result.MathError(e => Snackbar.Add(e.Detail, Severity.Error));
    }
}
