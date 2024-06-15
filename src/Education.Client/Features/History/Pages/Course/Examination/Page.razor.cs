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
    private readonly List<string> _requiredExaminations = [];
    private ApiResult<ExaminationBuilderModel> _response = ApiResult<ExaminationBuilderModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryCourseClient CourseClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Parameter]
    public required string Id { get; set; }

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Courses_Title"], HistoryUrl.Content.Courses()),
        new BreadcrumbItem(L["Examinations_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _response = await CourseClient.GetExaminationAsync(Id);
        _response.Match(
            x =>
            {
                foreach (var quiz in x.Examinations)
                {
                    switch (quiz.Difficulty)
                    {
                        case DifficultyType.Easy when (x.Activity?.IsEasyExaminationCompleted ?? false) == false:
                        case DifficultyType.Hard when (x.Activity?.IsHardExaminationCompleted ?? false) == false:
                            _requiredExaminations.Add($"<b>\"{L.GetExaminationDifficultyTitle(quiz.Difficulty)}\"</b> ");
                            break;
                    }
                }
            },
            e =>
            {
                if (e.IsExaminationAlreadyCreated(out var id))
                    NavigationManager.NavigateTo(HistoryUrl.Examination.Test(id));
            }
        );
    }

    private async Task CreateTestAsync(DifficultyType difficulty)
    {
        var result = await CourseClient.CreateExaminationAsync(Id, new CreateExaminationRequest(difficulty));
        result.Match(
            x => NavigationManager.NavigateTo(HistoryUrl.Examination.Test(x.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );
    }
}
