using Education.Client.Clients;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations.Conclusion;

public sealed partial class Page
{
    private ApiResult<ExaminationConclusionModel> _result = ApiResult<ExaminationConclusionModel>.Loading();

    [Inject]
    private IHistoryExaminationClient ExaminationClient { get; init; } = default!;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync() =>
        _result = await ExaminationClient.GetConclusionAsync(Id);

    private static Severity GetColor(ExaminationStatus status) =>
        status switch
        {
            ExaminationStatus.Succeeded => Severity.Success,
            ExaminationStatus.Failed => Severity.Error,
            ExaminationStatus.TimeExceeded => Severity.Warning,
            _ => Severity.Info
        };
}
