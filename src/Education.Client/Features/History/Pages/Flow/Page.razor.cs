using Education.Client.Clients;
using Education.Client.Features.History.Clients.Flow;
using Education.Client.Features.History.Clients.Flow.Model;
using Education.Client.Models.Test;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.History.Pages.Flow;

public sealed partial class Page : ComponentBase
{
    private readonly IHistoryFlowClient _flowClient;
    private readonly IStringLocalizer<App> _localizer;
    private AnswerResult? _correctAnswer;
    private ApiResult<FlowModel> _response = ApiResult<FlowModel>.Loading();

    public Page(IStringLocalizer<App> localizer, IHistoryFlowClient flowClient)
    {
        _localizer = localizer;
        _flowClient = flowClient;
    }

    protected override async Task OnInitializedAsync() =>
        _response = await _flowClient.GetAsync();

    private async Task OnStartClick()
    {
        _response = ApiResult<FlowModel>.Loading();
        _response = await _flowClient.StartAsync();
    }

    private async Task OnAnswerClick(UserAnswerModel answer)
    {
        var flow = _response.Unwrap();
        var response = await _flowClient.CheckAsync(flow.Question.Id, answer);

        _response = response
            .Map(x =>
            {
                _correctAnswer = x.Answer;
                return flow with
                {
                    Streak = x.Streak,
                    Track = x.Track,
                    Bank = x.Bank
                };
            });
    }

    private async Task OnNextQuestion()
    {
        _correctAnswer = null;
        _response = await _flowClient.GetAsync();
    }

    private async Task OnBankCollect()
    {
        var response = await _flowClient.CollectBankAsync();

        _response = response
            .Map(_ => _response.Unwrap() with
            {
                Bank = []
            });
    }
}
