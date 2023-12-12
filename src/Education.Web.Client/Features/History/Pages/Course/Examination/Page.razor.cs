using Blazored.LocalStorage;
using Education.Web.Client.Features.History.Services.Course;
using Education.Web.Client.Features.History.Services.Course.Model;
using Education.Web.Client.Features.History.Services.Learner;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Course.Examination;

public sealed partial class Page
{
    private ApiResult<ExaminationBuilderModel> _result = ApiResult<ExaminationBuilderModel>.Loading();
    private DifficultyType? _difficulty;
    private bool _isLoading;

    [Inject]
    private IStringLocalizer<App> L { get; set; } = default!;

    [Inject]
    private IHistoryCourseService CourseService { get; set; } = default!;

    [Inject]
    private IHistoryLearnerService LearnerService { get; set; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; init; } = default!;

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

        _result = await CourseService.GetExaminationAsync(Id);
        await _result.MatchAsync(x =>
            x.Examinations.Any(e => e.IsAllowed && e.Type == _difficulty)
                ? Task.CompletedTask
                : DifficultyChanged(x.Examinations.FirstOrDefault(t => t.IsAllowed)?.Type)
        );
    }

    private Task CreateTestAsync()
    {
        _isLoading = true;
        return Task.CompletedTask;
    }

    private async Task DifficultyChanged(DifficultyType? difficulty)
    {
        _difficulty = difficulty;

        await Storage.SetItemAsync(HistoryLocalStorageKey.ExaminationSettings, difficulty);
    }
}
