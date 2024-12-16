using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.Course;
using Education.Client.Features.History.Clients.Course.Model;
using Education.Client.Features.History.Clients.Course.Request;
using Education.Client.Features.History.Clients.Learner;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Course.Examination;

public sealed partial class Page : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryCourseClient _courseClient;
    private readonly IHistoryLearnerClient _learnerClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigationManager;
    private readonly List<string> _requiredExaminations = [];
    private readonly ISnackbar _snackbar;
    private ApiResult<ExaminationBuilderModel> _response = ApiResult<ExaminationBuilderModel>.Loading();

    public Page(
        IStringLocalizer<App> localizer,
        IHistoryCourseClient courseClient,
        IHistoryLearnerClient learnerClient,
        NavigationManager navigationManager,
        ISnackbar snackbar
    )
    {
        _localizer = localizer;
        _courseClient = courseClient;
        _learnerClient = learnerClient;
        _navigationManager = navigationManager;
        _snackbar = snackbar;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["Courses_Title"], HistoryUrl.Content.Courses()),
            new BreadcrumbItem(_localizer["Examinations_Title"], null, true)
        ];
    }

    [Parameter]
    public required string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _response = await _courseClient.GetExaminationAsync(Id);
        _response.Match(
            x =>
            {
                foreach (var quiz in x.Examinations)
                {
                    switch (quiz.Difficulty)
                    {
                        case DifficultyType.Easy when (x.Activity?.IsEasyExaminationCompleted ?? false) == false:
                        case DifficultyType.Hard when (x.Activity?.IsHardExaminationCompleted ?? false) == false:
                            _requiredExaminations.Add(
                                $"<b>\"{_localizer.GetExaminationDifficultyTitle(quiz.Difficulty)}\"</b> ");
                            break;
                    }
                }
            },
            e =>
            {
                if (e.IsExaminationAlreadyCreated(out var id))
                    _navigationManager.NavigateTo(HistoryUrl.Examination.Test(id));
            }
        );
    }

    private async Task CreateTestAsync(DifficultyType difficulty)
    {
        var result = await _courseClient.CreateExaminationAsync(Id, new CreateExaminationRequest(difficulty));
        result.Match(
            x => _navigationManager.NavigateTo(HistoryUrl.Examination.Test(x.Id)),
            e => _snackbar.Add(e.UiMessage, Severity.Error)
        );
    }
}
