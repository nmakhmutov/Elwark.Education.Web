using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Flow;

public sealed partial class Page
{
    private AnswerResult? _correctAnswer;
    private ApiResult<FlowModel> _result = ApiResult<FlowModel>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryFlowClient FlowClient { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["Flow_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync() =>
        _result = await FlowClient.GetAsync();

    private async Task OnStartClick()
    {
        _result = ApiResult<FlowModel>.Loading();
        _result = await FlowClient.StartAsync();
    }

    private async Task OnAnswerClick(UserAnswerModel answer)
    {
        var flow = _result.Unwrap();
        _result = (await FlowClient.CheckAsync(flow.Question.Id, answer))
            .Map(x =>
            {
                _correctAnswer = x.Answer;
                return flow with
                {
                    Streak = x.Streak,
                    Bank = x.Bank
                };
            });
    }

    private async Task OnNextQuestion()
    {
        _correctAnswer = null;
        _result = await FlowClient.GetAsync();
    }

    private async Task OnBankCollect() =>
        _result = (await FlowClient.CollectBankAsync())
            .Map(_ => _result.Unwrap() with
            {
                Bank = []
            });
}
