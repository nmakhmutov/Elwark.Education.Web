using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.Flow;

public sealed partial class Page : ComponentBase
{
    private AnswerResult? _correctAnswer;
    private ApiResult<FlowModel> _response = ApiResult<FlowModel>.Loading();

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
        _response = await FlowClient.GetAsync();

    private async Task OnStartClick()
    {
        _response = ApiResult<FlowModel>.Loading();
        _response = await FlowClient.StartAsync();
    }

    private async Task OnAnswerClick(UserAnswerModel answer)
    {
        var flow = _response.Unwrap();
        var response = await FlowClient.CheckAsync(flow.Question.Id, answer);

        _response = response
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
        _response = await FlowClient.GetAsync();
    }

    private async Task OnBankCollect()
    {
        var response = await FlowClient.CollectBankAsync();
        _response = response
            .Map(_ => _response.Unwrap() with
            {
                Bank = []
            });
    }
}
