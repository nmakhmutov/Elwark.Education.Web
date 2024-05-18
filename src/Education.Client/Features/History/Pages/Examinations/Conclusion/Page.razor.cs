using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations.Conclusion;

public sealed partial class Page : ComponentBase
{
    private ApiResult<ExaminationConclusionModel> _result = ApiResult<ExaminationConclusionModel>.Loading();

    [Inject]
    private IHistoryExaminationClient ExaminationClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _result = await ExaminationClient.GetConclusionAsync(Id);

        if (_result.MatchError(x => x.IsExaminationNotFound()))
            Navigation.NavigateTo(HistoryUrl.Content.Courses());
    }

    private static Severity GetColor(ExaminationStatus status) =>
        status switch
        {
            ExaminationStatus.Succeeded => Severity.Success,
            ExaminationStatus.Failed => Severity.Error,
            ExaminationStatus.TimeExceeded => Severity.Warning,
            _ => Severity.Info
        };

    private static string GetCheckIcon(bool isChecked) =>
        isChecked ? Icons.Material.Outlined.Check : Icons.Material.Outlined.Close;
}
