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

public sealed partial class Page
{
    private ApiResult<ExaminationBuilderModel> _result = ApiResult<ExaminationBuilderModel>.Loading();

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
        _result = await CourseClient.GetExaminationAsync(Id);
        _result.MathError(x =>
        {
            if (x.IsExaminationAlreadyCreated(out var id))
                NavigationManager.NavigateTo(HistoryUrl.Examination.Test(id));
        });
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
