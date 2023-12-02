using Education.Web.Client.Features.History.Services.Flow;
using Education.Web.Client.Features.History.Services.Flow.Model;
using Education.Web.Client.Http;
using Education.Web.Client.Models.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.Flow;

public sealed partial class Page
{
    private AnswerResult? _correctAnswer;
    private ApiResult<FlowModel> _result = ApiResult<FlowModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryFlowService FlowService { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Flow_Title"], null, true)
    ];
    
    protected override async Task OnInitializedAsync() =>
        _result = await FlowService.GetAsync();

    private async Task OnStartClick()
    {
        _result = ApiResult<FlowModel>.Loading();
        _result = await FlowService.StartAsync();
    }

    private async Task OnAnswerClick(AnswerToQuestionModel answer)
    {
        var flow = _result.Unwrap();
        _result = (await FlowService.CheckAsync(flow.Question.Id, answer))
            .Map(x =>
            {
                _correctAnswer = x.Answer;
                return flow with { Streak = x.Streak, Bank = x.Bank };
            });
    }

    private async Task OnNextQuestion()
    {
        _correctAnswer = null;
        _result = await FlowService.GetAsync();
    }

    private async Task OnBankCollect() =>
        _result = (await FlowService.CollectBankAsync())
            .Map(_ => _result.Unwrap() with { Bank = [] });
}
