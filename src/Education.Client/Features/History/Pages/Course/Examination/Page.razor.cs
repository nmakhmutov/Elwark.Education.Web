using Blazored.LocalStorage;
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
    private DifficultyType? _difficulty;
    private bool _isLoading;
    private ApiResult<ExaminationBuilderModel> _result = ApiResult<ExaminationBuilderModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryCourseClient CourseClient { get; init; } = default!;

    [Inject]
    private IHistoryLearnerClient LearnerClient { get; init; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; init; } = default!;

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
        _difficulty = await Storage.GetItemAsync<DifficultyType?>(HistoryLocalStorageKey.ExaminationSettings);

        _result = await CourseClient.GetExaminationAsync(Id);
        await _result.MatchAsync(
            x => x.Examinations.Any(e => e.IsAllowed && e.Type == _difficulty)
                ? Task.CompletedTask
                : ChangeDifficulty(x.Examinations.FirstOrDefault(t => t.IsAllowed)?.Type),
            e =>
            {
                if (e.IsExaminationAlreadyCreated(out var id))
                    NavigationManager.NavigateTo(HistoryUrl.Examination.Test(id));
            }
        );
    }

    private async Task CreateTestAsync()
    {
        if (!_difficulty.HasValue)
            return;

        _isLoading = true;

        var result = await CourseClient.CreateExaminationAsync(Id, new CreateExaminationRequest(_difficulty.Value));
        result.Match(
            x => NavigationManager.NavigateTo(HistoryUrl.Examination.Test(x.Id)),
            e => Snackbar.Add(e.Detail, Severity.Error)
        );

        _isLoading = false;
    }

    private async Task ChangeDifficulty(DifficultyType? difficulty)
    {
        _difficulty = difficulty;

        await Storage.SetItemAsync(HistoryLocalStorageKey.ExaminationSettings, difficulty);
    }
}
