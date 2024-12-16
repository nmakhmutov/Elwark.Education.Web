using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Examination;
using Education.Client.Features.History.Clients.Examination.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Examinations;

public sealed partial class ExaminationConclusionPage : ComponentBase
{
    private readonly IHistoryExaminationClient _examinationClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private ApiResult<ExaminationConclusionModel> _response = ApiResult<ExaminationConclusionModel>.Loading();

    public ExaminationConclusionPage(IHistoryExaminationClient examinationClient, IStringLocalizer<App> localizer,
        NavigationManager navigation)
    {
        _examinationClient = examinationClient;
        _localizer = localizer;
        _navigation = navigation;
    }

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _response = await _examinationClient.GetConclusionAsync(Id);

        if (_response.MatchError(x => x.IsExaminationNotFound()))
            _navigation.NavigateTo(HistoryUrl.Content.Courses());
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
