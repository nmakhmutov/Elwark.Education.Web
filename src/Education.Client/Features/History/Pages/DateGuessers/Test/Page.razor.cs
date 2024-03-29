using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.DateGuessers.Test;

public sealed partial class Page
{
    private uint _completedQuestions;
    private DateGuesserModel.QuestionModel _question = default!;
    private ApiResult<DateGuesserModel> _result = ApiResult<DateGuesserModel>.Loading();
    private ScoreModel _score = new(0, 0, 0);
    private uint _totalQuestions;
    private DateTime _x2BonusUntil;

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryDateGuesserClient DateGuesserClient { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["History_DateGuessers_Title"], null, true)
    ];

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _result = await DateGuesserClient.GetAsync(Id);
        _result.Match(
            x =>
            {
                _score = x.Score;
                _x2BonusUntil = x.X2BonusUntil;
                _completedQuestions = x.CompletedQuestions;
                _totalQuestions = x.TotalQuestions;
                _question = x.Question!;
            },
            e =>
            {
                if (e.IsDateGuesserNotFound())
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
            }
        );
    }

    private async Task OnValidSubmit(DateGuesserForm.Model model)
    {
        var year = model.Year.GetValueOrDefault();
        var request = new CheckRequest(model.IsCe ? year : -year, model.Month, model.Day);

        var result = await DateGuesserClient.CheckAsync(Id, _question.Id, request);
        result.Match(
            x =>
            {
                if (x.Question is null)
                {
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Conclusion(Id));
                    return;
                }

                _score = x.Score;
                _x2BonusUntil = x.X2BonusUntil;
                _question = x.Question;
                _completedQuestions = x.CompletedQuestions;
                _totalQuestions = x.TotalQuestions;
            },
            e => Snackbar.Add(e.Detail, Severity.Error)
        );
    }
}
